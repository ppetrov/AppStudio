using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppStudio.Config;
using AppStudio.Db;

namespace AppStudio.Generators
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

			public static ClassProperty From(Column column, EntityConfig[] referenceEntityConfigs)
			{
				if (column == null) throw new ArgumentNullException(nameof(column));
				if (referenceEntityConfigs == null) throw new ArgumentNullException(nameof(referenceEntityConfigs));

				var type = MapType(column, referenceEntityConfigs);

				var name = column.ForeignKey == null
					? NameProvider.GetPropertyName(column.Name)
					: NameProvider.GetPropertyName(type.Key);

				return new ClassProperty(type.Key, type.Value, name, @"{ get; }");
			}
		}

		public static void GenerateClass(StringBuilder buffer, Table table, ProjectConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			var entityConfig = config.GetEntityConfig(table.Name);

			buffer.Append(@"public");
			buffer.Append(@" ");
			buffer.Append(@"sealed");
			buffer.Append(@" ");
			buffer.Append(@"class");
			buffer.Append(@" ");
			buffer.AppendLine(entityConfig.ClassName);
			buffer.AppendLine(@"{");

			var referenceEntityConfigs = config.GetReferenceEntityConfigs(table);

			var properties = new List<ClassProperty>();

			foreach (var column in entityConfig.GetSelectColumns(table.Columns))
			{
				properties.Add(ClassProperty.From(column, referenceEntityConfigs));
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

			if (true)
			{
				// Constructor
				buffer.AppendLine();
				buffer.Append('\t');
				buffer.Append(@"public");
				buffer.Append(@" ");
				buffer.Append(entityConfig.ClassName);
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

		public static void GenerateGetAll(StringBuilder buffer, Table table, ProjectConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			var template = @"
public static Dictionary<long, {1}> Get{2}(IDbContext dbContext, DataCache cache)
{{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new Dictionary<long, {1}>();
	{4}
	var query = new Query<{1}>(@""{0}"", r =>
	{{
		{3}
	}});
	foreach (var item in dbContext.Execute(query))
	{{
		items.Add(item.Id, item);
	}}

	return items;
}}";

			var entityConfig = config.GetEntityConfig(table.Name);
			var referenceEntityConfigs = config.GetReferenceEntityConfigs(table);

			var creator = CreateCreatorMethod(table, referenceEntityConfigs, entityConfig);

			var cache = new StringBuilder();
			foreach (var referenceEntityConfig in referenceEntityConfigs)
			{
				if (cache.Length > 0)
				{
					cache.AppendLine();
				}

				cache.Append(@"var");
				cache.Append(@" ");
				cache.Append(NameProvider.GetVariableName(referenceEntityConfig.ClassPluralName));
				cache.Append(@" = ");
				cache.Append(@"cache.GetData");
				cache.Append(@"<");
				cache.Append(referenceEntityConfig.ClassName);
				cache.Append(@">");
				cache.Append(@"(");
				cache.Append(@"dbContext");
				cache.Append(@")");
				cache.Append(@";");
			}
			if (cache.Length > 0)
			{
				cache.Insert(0, Environment.NewLine);
				cache.AppendLine();
			}

			var selectSql = new StringBuilder();
			SqlGenerator.Select(selectSql, table, entityConfig);
			buffer.AppendFormat(template, selectSql, entityConfig.ClassName, entityConfig.ClassPluralName, creator, cache);
		}

		private static StringBuilder CreateCreatorMethod(Table table, EntityConfig[] referenceEntityConfigs, EntityConfig entityConfig)
		{
			var creator = new StringBuilder();

			var properties = new List<ClassProperty>(table.Columns.Length);

			var index = 0;
			foreach (var column in entityConfig.GetSelectColumns(table.Columns))
			{
				var property = ClassProperty.From(column, referenceEntityConfigs);

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
				if (column.ForeignKey != null)
				{
					creator.Append(NameProvider.GetVariableName(GetForeignKeyEntityConfig(referenceEntityConfigs, column).ClassPluralName));
					creator.Append(@"[");
				}
				ReadValue(creator, column, index++);
				if (column.ForeignKey != null)
				{
					creator.Append(@"]");
				}
				creator.Append(@";");
			}

			creator.AppendLine();
			creator.Append("\t\t");
			creator.AppendFormat(@"return new {0}({1});", entityConfig.ClassName, string.Join(@", ", properties.Select(p => p.VariableName)));

			return creator;
		}

		private static void ReadValue(StringBuilder buffer, Column column, int index)
		{
			switch (column.Type)
			{
				case SqlDataType.Int:
					buffer.AppendFormat(@"Query.GetInt(r, {0})", index);
					break;
				case SqlDataType.Long:
					buffer.AppendFormat(@"Query.GetLong(r, {0})", index);
					break;
				case SqlDataType.Decimal:
					buffer.AppendFormat(@"Query.GetDecimal(r, {0})", index);
					break;
				case SqlDataType.DateTime:
					buffer.AppendFormat(@"Query.GetDateTime(r, {0})", index);
					break;
				case SqlDataType.String:
					buffer.AppendFormat(@"Query.GetString(r, {0})", index);
					break;
				case SqlDataType.ByteArray:
					buffer.AppendFormat(@"Query.GetByteArray(r, {0})", index);
					break;
				case SqlDataType.Guid:
					buffer.AppendFormat(@"Query.GetGuid(r, {0})", index);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private static KeyValuePair<string, bool> MapType(Column column, EntityConfig[] referenceEntityConfigs)
		{
			if (column.ForeignKey == null)
			{
				switch (column.Type)
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
						throw new ArgumentOutOfRangeException(nameof(column.Type), column.Type, null);
				}
			}

			return new KeyValuePair<string, bool>(GetForeignKeyEntityConfig(referenceEntityConfigs, column).ClassName, true);
		}

		private static EntityConfig GetForeignKeyEntityConfig(EntityConfig[] referenceEntityConfigs, Column column)
		{
			if (column == null) throw new ArgumentNullException(nameof(column));
			if (referenceEntityConfigs == null) throw new ArgumentNullException(nameof(referenceEntityConfigs));

			var tableName = column.ForeignKey.TableName;
			foreach (var cfg in referenceEntityConfigs)
			{
				if (cfg.TableName == tableName)
				{
					return cfg;
				}
			}

			return null;
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