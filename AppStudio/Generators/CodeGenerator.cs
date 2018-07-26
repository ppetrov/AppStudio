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
			public string VariableName { get; }
			public string VariableDeclaration { get; }

			private ClassProperty(string type, bool isReferenceType, string name, string body)
			{
				this.Type = type;
				this.IsReferenceType = isReferenceType;
				this.Name = name;
				this.Body = body;
				this.VariableName = NameProvider.GetVariableName(name);
				this.VariableDeclaration = type + @" " + this.VariableName;
			}

			public static ClassProperty From(Column column, ProjectConfig config)
			{
				var type = MapType(column, config);

				var name = column.ForeignKey == null
					? NameProvider.GetPropertyName(column.Name)
					: type.Key;

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

			var properties = new List<ClassProperty>();

			foreach (var column in entityConfig.GetSelectColumns(table.Columns))
			{
				properties.Add(ClassProperty.From(column, config));
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
				buffer.AppendLine();
			}

			CreateConstructor(buffer, entityConfig, properties);

			buffer.AppendLine(@"}");
		}

		private static void CreateConstructor(StringBuilder buffer, EntityConfig entityConfig, List<ClassProperty> properties)
		{
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

			var creator = CreatorMethod(table, config);

			var entityConfig = config.GetEntityConfig(table.Name);

			var cache = new StringBuilder();
			foreach (var column in entityConfig.GetSelectColumns(table.Columns))
			{
				if (column.ForeignKey != null)
				{
					if (cache.Length > 0)
					{
						cache.AppendLine();
					}

					var referenceEntityConfig = config.GetEntityConfig(column.ForeignKey.TableName);

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

		private static StringBuilder CreatorMethod(Table table, ProjectConfig config)
		{
			var creator = new StringBuilder();

			var entityConfig = config.GetEntityConfig(table.Name);

			var properties = new List<ClassProperty>(table.Columns.Length);

			var index = 0;
			foreach (var column in entityConfig.GetSelectColumns(table.Columns))
			{
				var property = ClassProperty.From(column, config);

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
					creator.Append(NameProvider.GetVariableName(config.GetEntityConfig(column.ForeignKey.TableName).ClassPluralName));
					creator.Append(@"[");
				}
				ReadDbValue(creator, column, index++);
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

		private static void ReadDbValue(StringBuilder buffer, Column column, int index)
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
					// Apply convention for dates
					if (column.Name.IndexOf(@"_FROM", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						buffer.Append(@" ");
						buffer.Append(@"??");
						buffer.Append(@" ");
						buffer.Append(@"DateTime.MinValue");
					}
					if (column.Name.IndexOf(@"_TO", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						buffer.Append(@" ");
						buffer.Append(@"??");
						buffer.Append(@" ");
						buffer.Append(@"DateTime.MaxValue");
					}
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

		private static KeyValuePair<string, bool> MapType(Column column, ProjectConfig config)
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

			return new KeyValuePair<string, bool>(config.GetEntityConfig(column.ForeignKey.TableName).ClassName, true);
		}
	}
}