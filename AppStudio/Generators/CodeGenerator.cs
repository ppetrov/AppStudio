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
			public readonly Column Column;
			public readonly string Type;
			public readonly bool IsReferenceType;
			public readonly string Name;
			public readonly string VariableName;

			private ClassProperty(Column column, string type, bool isReferenceType, string name)
			{
				this.Column = column;
				this.Type = type;
				this.IsReferenceType = isReferenceType;
				this.Name = name;
				this.VariableName = NameProvider.GetVariableName(name);
			}

			public static ClassProperty From(Column column, ProjectConfig config)
			{
				var type = MapType(column, config);

				var name = column.ForeignKey == null
					? NameProvider.GetPropertyName(column.Name)
					: type.Key;

				return new ClassProperty(column, type.Key, type.Value, name);
			}
		}

		public static void GenerateClass(StringBuilder buffer, Table table, ProjectConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			var entityConfig = config.GetEntityConfig(table.Name);
			var className = entityConfig.ClassName;

			// Definition
			buffer.Append(@"public");
			buffer.Append(@" ");
			buffer.Append(@"sealed");
			buffer.Append(@" ");
			buffer.Append(@"class");
			buffer.Append(@" ");
			buffer.AppendLine(className);
			buffer.AppendLine(@"{");

			var properties = GetProperties(table, config, entityConfig);
			// Properties
			AppendProperties(buffer, properties);

			buffer.AppendLine();

			// Constructor
			AppendConstructor(buffer, properties, className);

			buffer.AppendLine(@"}");
		}

		private static List<ClassProperty> GetProperties(Table table, ProjectConfig config, EntityConfig entityConfig)
		{
			var properties = new List<ClassProperty>(table.Columns.Length);

			foreach (var column in entityConfig.GetSelectColumns(table.Columns))
			{
				properties.Add(ClassProperty.From(column, config));
			}

			return properties;
		}

		private static void AppendProperties(StringBuilder buffer, IEnumerable<ClassProperty> properties)
		{
			foreach (var property in properties)
			{
				buffer.Append('\t');
				buffer.Append(@"public");
				buffer.Append(@" ");
				buffer.Append(property.Type);
				buffer.Append(@" ");
				buffer.Append(property.Name);
				buffer.Append(@" ");
				buffer.Append(@"{ get; }");
				buffer.AppendLine();
			}
		}

		private static void AppendConstructor(StringBuilder buffer, List<ClassProperty> properties, string className)
		{
			buffer.Append('\t');
			buffer.Append(@"public");
			buffer.Append(@" ");
			buffer.Append(className);
			buffer.Append(@"(");
			// Parameters
			AppendConstructorParameters(buffer, properties);
			buffer.Append(@")");
			buffer.AppendLine();

			buffer.Append('\t');
			buffer.AppendLine(@"{");

			// Parameters guards
			AppendParametersGuards(buffer, properties);

			// Assign Parameters
			AppendAssignParameters(buffer, properties);

			buffer.Append('\t');
			buffer.AppendLine(@"}");
		}

		private static void AppendConstructorParameters(StringBuilder buffer, IEnumerable<ClassProperty> properties)
		{
			var addComma = false;

			foreach (var property in properties)
			{
				if (addComma)
				{
					buffer.Append(@",");
					buffer.Append(@" ");
				}

				buffer.Append(property.Type);
				buffer.Append(@" ");
				buffer.Append(property.VariableName);

				addComma = true;
			}
		}

		private static void AppendParametersGuards(StringBuilder buffer, IEnumerable<ClassProperty> properties)
		{
			var hasGuards = false;

			foreach (var property in properties)
			{
				if (property.IsReferenceType)
				{
					hasGuards = true;

					var variableName = property.VariableName;
					buffer.Append("\t\t");
					buffer.AppendFormat($"if ({variableName} == null) throw new ArgumentNullException(nameof({variableName}));");
					buffer.AppendLine();
				}
			}

			if (hasGuards)
			{
				buffer.AppendLine();
			}
		}

		private static void AppendAssignParameters(StringBuilder buffer, IEnumerable<ClassProperty> properties)
		{
			foreach (var property in properties)
			{
				buffer.Append("\t\t");
				buffer.Append(@"this");
				buffer.Append(@".");
				buffer.Append(property.Name);
				buffer.Append(@" = ");
				buffer.Append(property.VariableName);
				buffer.Append(@";");
				buffer.AppendLine();
			}
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
			var className = entityConfig.ClassName;
			var properties = GetProperties(table, config, entityConfig);

			var creator = CreatorMethod(table, config, properties);


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

		private static StringBuilder CreatorMethod(Table table, ProjectConfig config, IEnumerable<ClassProperty> properties)
		{
			var creator = new StringBuilder();

			var entityConfig = config.GetEntityConfig(table.Name);

			var index = 0;
			foreach (var property in properties)
			{
				if (creator.Length > 0)
				{
					creator.AppendLine();
					creator.Append("\t\t");
				}

				var column = property.Column;

				creator.Append(@"var");
				creator.Append(@" ");
				creator.Append(property.VariableName);
				creator.Append(@" = ");
				if (column.ForeignKey != null)
				{
					creator.Append(NameProvider.GetVariableName(config.GetEntityConfig(column.ForeignKey.TableName).ClassPluralName));
					creator.Append(@"[");
				}
				ReadDbValue(creator, column.Type, column.Name, index++);
				if (column.ForeignKey != null)
				{
					creator.Append(@"]");
				}
				creator.Append(@";");
			}

			creator.AppendLine();
			creator.Append("\t\t");
			creator.AppendLine();
			creator.Append("\t\t");
			creator.AppendFormat(@"return new {0}({1});", entityConfig.ClassName, string.Join(@", ", properties.Select(p => p.VariableName)));

			return creator;
		}

		private static void ReadDbValue(StringBuilder buffer, SqlDataType type, string name, int index)
		{
			switch (type)
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
					if (name.IndexOf(@"_FROM", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						buffer.Append(@" ");
						buffer.Append(@"??");
						buffer.Append(@" ");
						buffer.Append(@"DateTime.MinValue");
					}
					if (name.IndexOf(@"_TO", StringComparison.OrdinalIgnoreCase) >= 0)
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
				return MapType(column.Type);
			}

			return new KeyValuePair<string, bool>(config.GetEntityConfig(column.ForeignKey.TableName).ClassName, true);
		}

		private static KeyValuePair<string, bool> MapType(SqlDataType type)
		{
			switch (type)
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
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
		}
	}
}