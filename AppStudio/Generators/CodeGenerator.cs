using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppStudio.Config;
using AppStudio.Generators;

namespace AppStudio.Db
{
	public static class CodeGenerator
	{
		private sealed class ClassProperty
		{
			public string Type { get; }
			public bool IsReferenceType { get; }
			public string Name { get; }
			public string Body { get; }
			public string Initialization { get; }
			public string VariableName { get; }
			public string VariableDeclaration { get; }

			private ClassProperty(string type, bool isReferenceType, string name, string body, string initialization = "")
			{
				this.Type = type;
				this.IsReferenceType = isReferenceType;
				this.Name = name;
				this.Body = body;
				this.Initialization = initialization;
				this.VariableName = NameProvider.GetVariableName(name);
				this.VariableDeclaration = type + @" " + this.VariableName;
			}

			public static ClassProperty From(Column column, bool readOnly)
			{
				var type = MapType(column.Type);
				var name = NameProvider.GetPropertyName(column.Name);
				if (readOnly)
				{
					return new ClassProperty(type.Key, type.Value, name, @"{ get; }");
				}
				return new ClassProperty(type.Key, type.Value, name, @"{ get; set; }", @" = " + GetDefaultValue(column) + @";");
			}
		}

		public static void GenerateClass(StringBuilder buffer, Table table, EntityConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			buffer.Append(@"public");
			buffer.Append(@" ");
			buffer.Append(@"sealed");
			buffer.Append(@" ");
			buffer.Append(@"class");
			buffer.Append(@" ");
			buffer.AppendLine(config.ClassName);
			buffer.AppendLine(@"{");

			var readOnly = config.AsReadOnly;
			var properties = new List<ClassProperty>();

			foreach (var column in config.GetSelectColumns(table.Columns))
			{
				properties.Add(ClassProperty.From(column, readOnly));
			}

			foreach (var property in properties)
			{
				buffer.Append('\t');
				buffer.Append(@"public");
				buffer.Append(@" ");
				buffer.Append(property.Type);
				buffer.Append(@" ");
				buffer.Append(property.Name);
				buffer.Append(@" ");
				buffer.Append(property.Body);
				if (property.Initialization != string.Empty)
				{
					buffer.Append(property.Initialization);
				}
				buffer.AppendLine();
			}

			if (readOnly)
			{
				// Constructor
				buffer.AppendLine();
				buffer.Append('\t');
				buffer.Append(@"public");
				buffer.Append(@" ");
				buffer.Append(config.ClassName);
				buffer.Append(@"(");
				// Parameters
				var addComma = false;
				foreach (var property in properties)
				{
					if (addComma)
					{
						buffer.Append(@",");
						buffer.Append(@" ");
					}
					buffer.Append(property.VariableDeclaration);
					addComma = true;
				}

				buffer.Append(@")");
				buffer.AppendLine();
				buffer.Append('\t');
				buffer.AppendLine(@"{");

				// Add guards
				var hasGuards = false;
				foreach (var property in properties)
				{
					if (property.IsReferenceType)
					{
						hasGuards = true;
						var varName = property.VariableName;
						buffer.AppendFormat($"\t\tif ({varName} == null) throw new ArgumentNullException(nameof({varName}));");
						buffer.AppendLine();
					}
				}

				if (hasGuards)
				{
					buffer.AppendLine();
				}

				// Assign parameters to properties
				foreach (var property in properties)
				{
					buffer.Append("\t\tthis.");
					buffer.Append(property.Name);
					buffer.Append(@" = ");
					buffer.Append(property.VariableName);
					buffer.Append(@";");
					buffer.AppendLine();
				}

				buffer.Append('\t');
				buffer.AppendLine(@"}");
			}

			buffer.AppendLine(@"}");
		}

		public static void GenerateGetAll(StringBuilder buffer, Table table, EntityConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			var template = @"
public static List<{1}> Get{2}(IDbContext context)
{{
	if (context == null) throw new ArgumentNullException(nameof(context));

	var items = new List<{1}>();

	var query = new Query<{1}>(@""{0}"", r =>
	{{
		{3}
	}});
	foreach (var item in context.Execute(query))
	{{
		items.Add(item);
	}}

	return items;
}}";
			var creator = new StringBuilder();
			var properties = new List<ClassProperty>(table.Columns.Length);
			foreach (var column in config.GetSelectColumns(table.Columns))
			{
				var property = ClassProperty.From(column, config.AsReadOnly);

				properties.Add(property);

				if (creator.Length > 0)
				{
					creator.AppendLine();
					creator.Append("\t\t");
				}
				creator.Append(@"var");
				creator.Append(@" ");
				creator.Append(property.VariableName);
				creator.Append(@" = ");
				creator.Append(GetDefaultValue(column));
				creator.Append(@";");
			}


			creator.AppendLine();
			creator.Append("\t\t");
			creator.AppendFormat(@"return new {0}({1});", config.ClassName, string.Join(@", ", properties.Select(p => p.VariableName)));
			//var a = Query.GetLong(r, -1);
			//var b = Query.GetLong(r, -1);
			//return new ActivationCompliance("", 0, "", "");

			var selectSql = new StringBuilder();
			SqlGenerator.Select(selectSql, table, config);
			buffer.AppendFormat(template, selectSql.ToString(), config.ClassName, config.ClassPluralName, creator.ToString());
		}

		private static KeyValuePair<string, bool> MapType(SqlDataType dataType)
		{
			switch (dataType)
			{
				case SqlDataType.Int:
					return new KeyValuePair<string, bool>(@"int", false);
				case SqlDataType.Long:
					return new KeyValuePair<string, bool>(@"long", false);
				case SqlDataType.Decimal:
					return new KeyValuePair<string, bool>(@"decimal", false);
				case SqlDataType.DateTime:
					return new KeyValuePair<string, bool>(@"DateTime", false);
				case SqlDataType.String:
					return new KeyValuePair<string, bool>(@"string", true);
				case SqlDataType.ByteArray:
					return new KeyValuePair<string, bool>(@"byte[]", true);
				case SqlDataType.Guid:
					return new KeyValuePair<string, bool>(@"string", true);
				default:
					throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
			}
		}

		private static string GetDefaultValue(Column column)
		{
			// TODO : config the column as Min/Max for DateTime
			return GetDefaultValue(column.Type, false);
		}

		private static string GetDefaultValue(SqlDataType dataType, bool useDateTimeMax = false)
		{
			switch (dataType)
			{
				case SqlDataType.Int:
					return @"0";
				case SqlDataType.Long:
					return @"0L";
				case SqlDataType.Decimal:
					return @"0M";
				case SqlDataType.DateTime:
					return useDateTimeMax ? "DateTime.MaxValue" : "DateTime.MinValue";
				case SqlDataType.String:
					return @"string.Empty";
				case SqlDataType.ByteArray:
					return @"default(byte[])";
				case SqlDataType.Guid:
					return @"string.Empty";
				default:
					throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
			}
		}
	}
}