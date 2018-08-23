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
		private sealed class Property
		{
			public readonly Column Column;
			public readonly EntityConfig ReferenceEntityConfig;
			public readonly string Type;
			public readonly bool IsReferenceType;
			public readonly string Name;
			public readonly string VariableName;
			public readonly bool IsCaption;
			public readonly bool GenerateField = true;

			public Property(Column column, KeyValuePair<string, bool> type, string name, EntityConfig referenceEntityConfig, bool isCaption = false, bool generateField = true)
			{
				this.Column = column;
				this.ReferenceEntityConfig = referenceEntityConfig;
				this.Type = type.Key;
				this.IsReferenceType = type.Value;
				this.Name = name;
				this.VariableName = NameProvider.GetVariableName(name);
				this.IsCaption = isCaption;
				this.GenerateField = generateField;
			}

			private Property(Column column, string type, bool isReferenceType, string name, EntityConfig referenceEntityConfig)
			{
				this.Column = column;
				this.ReferenceEntityConfig = referenceEntityConfig;
				this.Type = type;
				this.IsReferenceType = isReferenceType;
				this.Name = name;
				this.VariableName = NameProvider.GetVariableName(name);
			}

			public static Property From(Column column, ProjectConfig config)
			{
				var type = MapType(column, config);

				string name;
				EntityConfig entityConfig;

				if (column.ForeignKey == null)
				{
					name = NameProvider.GetPropertyName(column.Name);
					entityConfig = null;
				}
				else
				{
					name = type.Key;
					entityConfig = config.GetEntityConfig(column.ForeignKey.TableName);
				}

				return new Property(column, type.Key, type.Value, name, entityConfig);
			}
		}

		public static void GenerateClass(StringBuilder buffer, Table table, ProjectConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			var entityConfig = config.GetEntityConfig(table.Name);
			var className = entityConfig.ClassName;
			var properties = GetProperties(table, config, entityConfig);

			GenerateClass(buffer, className, properties);
		}

		public static void GenerateCaptionsClass(StringBuilder buffer, Table table, ProjectConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			var entityConfig = config.GetEntityConfig(table.Name);
			var className = entityConfig.ClassName + @"Captions";
			var properties = GetProperties(table, config, entityConfig)
				.Where(v => !v.Column.IsPrimaryKey)
				.Select(v => new Property(v.Column, MapType(SqlDataType.String), v.Name, v.ReferenceEntityConfig))
				.ToList();

			GenerateClass(buffer, className, properties);
		}

		public static void GenerateViewModel(StringBuilder buffer, Table table, ProjectConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			var entityConfig = config.GetEntityConfig(table.Name);
			var modelClassName = entityConfig.ClassName;
			var captionsClassName = modelClassName + @"Captions";
			var className = modelClassName + @"ViewModel";
			var properties = GetProperties(table, config, entityConfig)
				.Where(v => !v.Column.IsPrimaryKey)
				.SelectMany(v => new[]
				{
					new Property(v.Column, MapType(SqlDataType.String), v.Name, v.ReferenceEntityConfig),
					new Property(v.Column, MapType(SqlDataType.String), v.Name, v.ReferenceEntityConfig, true),
				}).ToList();

			properties.Insert(0, new Property(null, new KeyValuePair<string, bool>(modelClassName, true), modelClassName, null));
			properties.Insert(1, new Property(null, new KeyValuePair<string, bool>(captionsClassName, true), @"Captions", null, generateField: false));

			GenerateClass(buffer, className, properties, @"ViewModel", AppendViewModelConstructor);
		}

		public static void GeneratePropertyEnum(StringBuilder buffer, Table table, ProjectConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			var entityConfig = config.GetEntityConfig(table.Name);
			var className = entityConfig.ClassName;
			var properties = GetProperties(table, config, entityConfig);

			// Definition
			buffer.Append(@"public");
			buffer.Append(@" ");
			buffer.Append(@"enum");
			buffer.Append(@" ");
			buffer.Append(className);
			buffer.Append(@"Property");
			buffer.AppendLine();
			buffer.AppendLine(@"{");

			// Entries
			foreach (var property in properties)
			{
				if (property.Column.IsPrimaryKey)
				{
					continue;
				}
				buffer.Append(property.Name);
				buffer.Append(@",");
				buffer.AppendLine();
			}

			buffer.AppendLine(@"}");
		}

		public static void GenerateGetAll(StringBuilder buffer, Table table, ProjectConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			var entityConfig = config.GetEntityConfig(table.Name);
			var className = entityConfig.ClassName;
			var properties = GetProperties(table, config, entityConfig);

			var dictionaries = GetDictionariesVariables(properties);
			if (dictionaries == string.Empty)
			{
				const string template = @"
public static IEnumerable<{0}> Get{1}(IDbContext dbContext)
{{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));

	var query = new Query<{0}>(@""{2}"", r =>
	{{
	{3}
	}});

	return dbContext.Execute(query);
}}";

				buffer.AppendFormat(template,
					className,
					entityConfig.ClassPluralName,
					SqlGenerator.Select(table, entityConfig),
					GetCreator(className, properties));
			}
			else
			{
				const string template = @"
public static IEnumerable<{0}> Get{1}(IDbContext dbContext, DataCache cache)
{{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new List<{0}>();
	{4}
	var query = new Query<{0}>(@""{2}"", r =>
	{{
	{3}
	}});
	foreach (var item in dbContext.Execute(query))
	{{
		items.Add(item);
	}}

	return items;
}}";

				buffer.AppendFormat(template,
					className,
					entityConfig.ClassPluralName,
					SqlGenerator.Select(table, entityConfig),
					GetCreator(className, properties),
					dictionaries);
			}
		}

		public static void GenerateGetAllAsDictionary(StringBuilder buffer, Table table, ProjectConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			const string template = @"
public static Dictionary<{5}, {0}> Get{1}(IDbContext dbContext, DataCache cache)
{{
	if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
	if (cache == null) throw new ArgumentNullException(nameof(cache));

	var items = new Dictionary<{5}, {0}>();
	{4}
	var query = new Query<{0}>(@""{2}"", r =>
	{{
	{3}
	}});
	foreach (var item in dbContext.Execute(query))
	{{
		items.Add(item.{6}, item);
	}}

	return items;
}}";

			var entityConfig = config.GetEntityConfig(table.Name);
			var className = entityConfig.ClassName;
			var properties = GetProperties(table, config, entityConfig);
			var pk = properties.SingleOrDefault(p => p.Column.IsPrimaryKey);
			var primaryKeyType = pk.Type;
			var primaryKey = pk.Name;

			buffer.AppendFormat(template,
				className,
				entityConfig.ClassPluralName,
				SqlGenerator.Select(table, entityConfig),
				GetCreator(className, properties),
				GetDictionariesVariables(properties),
				primaryKeyType,
				primaryKey);
		}


		private static List<Property> GetProperties(Table table, ProjectConfig config, EntityConfig entityConfig)
		{
			var properties = new List<Property>(table.Columns.Length);

			foreach (var column in entityConfig.GetSelectColumns(table.Columns))
			{
				properties.Add(Property.From(column, config));
			}

			return properties;
		}

		private static void GenerateClass(StringBuilder buffer, string className, List<Property> properties, string baseClass = "", Action<StringBuilder, List<Property>, string> constructor = null)
		{
			// Definition
			buffer.Append(@"public");
			buffer.Append(@" ");
			buffer.Append(@"sealed");
			buffer.Append(@" ");
			buffer.Append(@"class");
			buffer.Append(@" ");
			buffer.Append(className);
			if (!string.IsNullOrWhiteSpace(baseClass))
			{
				buffer.Append(@" ");
				buffer.Append(@":");
				buffer.Append(@" ");
				buffer.Append(baseClass);
			}
			buffer.AppendLine();
			buffer.AppendLine(@"{");

			// Properties
			AppendProperties(buffer, properties);

			buffer.AppendLine();

			// Constructor
			var currentConstructor = constructor ?? AppendConstructor;

			currentConstructor(buffer, properties, className);

			buffer.AppendLine(@"}");
		}

		private static void AppendProperties(StringBuilder buffer, IEnumerable<Property> properties)
		{
			foreach (var property in properties)
			{
				if (!property.GenerateField)
				{
					continue;
				}
				buffer.Append(@"public");
				buffer.Append(@" ");
				buffer.Append(property.Type);
				buffer.Append(@" ");
				buffer.Append(property.Name);
				if (property.IsCaption)
				{
					buffer.Append(@"Caption");
				}
				buffer.Append(@" ");
				buffer.Append(@"{ get; }");
				buffer.AppendLine();
			}
		}

		private static void AppendConstructor(StringBuilder buffer, List<Property> properties, string className)
		{
			buffer.Append(@"public");
			buffer.Append(@" ");
			buffer.Append(className);
			buffer.Append(@"(");
			// Parameters
			AppendConstructorParameters(buffer, properties);
			buffer.Append(@")");
			buffer.AppendLine();

			buffer.AppendLine(@"{");

			// Parameters guards
			AppendParametersGuards(buffer, properties);

			// Assign Parameters
			AppendAssignParameters(buffer, properties);

			buffer.AppendLine(@"}");
		}

		private static void AppendViewModelConstructor(StringBuilder buffer, List<Property> properties, string className)
		{
			var dataProperties = properties.Take(2).ToList();

			buffer.Append(@"public");
			buffer.Append(@" ");
			buffer.Append(className);
			buffer.Append(@"(");
			// Parameters			
			AppendConstructorParameters(buffer, dataProperties);
			buffer.Append(@")");
			buffer.AppendLine();

			buffer.AppendLine(@"{");

			// Parameters guards
			AppendParametersGuards(buffer, dataProperties);

			// Assign Parameters
			AppendAssignParameters(buffer, dataProperties.Take(1));
			AppendAssignViewModelParameters(buffer, dataProperties[0].VariableName, properties.Skip(2));

			buffer.AppendLine(@"}");
		}

		private static void AppendConstructorParameters(StringBuilder buffer, IEnumerable<Property> properties)
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

		private static void AppendParametersGuards(StringBuilder buffer, IEnumerable<Property> properties)
		{
			var hasGuards = false;

			foreach (var property in properties)
			{
				if (property.IsReferenceType)
				{
					hasGuards = true;

					var variableName = property.VariableName;
					buffer.AppendFormat($"if ({variableName} == null) throw new ArgumentNullException(nameof({variableName}));");
					buffer.AppendLine();
				}
			}

			if (hasGuards)
			{
				buffer.AppendLine();
			}
		}

		private static void AppendAssignParameters(StringBuilder buffer, IEnumerable<Property> properties)
		{
			foreach (var property in properties)
			{
				buffer.Append(@"this");
				buffer.Append(@".");
				buffer.Append(property.Name);
				buffer.Append(@" = ");
				buffer.Append(property.VariableName);
				buffer.Append(@";");
				buffer.AppendLine();
			}
		}

		private static void AppendAssignViewModelParameters(StringBuilder buffer, string modelName, IEnumerable<Property> properties)
		{
			foreach (var property in properties)
			{
				buffer.Append(@"this");
				buffer.Append(@".");
				buffer.Append(property.Name);
				if (property.IsCaption)
				{
					buffer.Append(@"Caption");
				}
				buffer.Append(@" = ");
				buffer.Append(property.IsCaption ? @"captions" : modelName);
				buffer.Append(@".");
				buffer.Append(property.Name);
				if (!property.IsCaption)
				{
					switch (property.Column.Type)
					{
						case SqlDataType.Int:
						case SqlDataType.Long:
							buffer.Append(@".");
							buffer.Append(@"ToString()");
							break;
						case SqlDataType.Decimal:
							buffer.Append(@".");
							buffer.Append(@"ToString(@""F2"")");
							break;
						case SqlDataType.DateTime:
							buffer.Append(@".");
							buffer.Append(@"ToString(@""dd MMM yyyy"")");
							break;
					}
				}

				buffer.Append(@";");
				buffer.AppendLine();
			}
		}

		private static string GetDictionariesVariables(IEnumerable<Property> properties)
		{
			var buffer = new StringBuilder();

			foreach (var property in properties)
			{
				var referenceEntityConfig = property.ReferenceEntityConfig;
				if (referenceEntityConfig != null)
				{
					if (buffer.Length > 0)
					{
						buffer.AppendLine();
					}

					buffer.Append(@"var");
					buffer.Append(@" ");
					buffer.Append(NameProvider.GetVariableName(referenceEntityConfig.ClassPluralName));
					buffer.Append(@" = ");
					buffer.Append(@"cache.GetData");
					buffer.Append(@"<");
					buffer.Append(referenceEntityConfig.ClassName);
					buffer.Append(@">");
					buffer.Append(@"(");
					buffer.Append(@"dbContext");
					buffer.Append(@")");
					buffer.Append(@";");
				}
			}

			if (buffer.Length > 0)
			{
				buffer.Insert(0, Environment.NewLine);
				buffer.AppendLine();
			}

			return buffer.ToString();
		}

		private static string GetCreator(string className, IEnumerable<Property> properties)
		{
			var buffer = new StringBuilder();
			var args = new StringBuilder();

			var index = 0;
			foreach (var property in properties)
			{
				if (buffer.Length > 0)
				{
					buffer.AppendLine();
				}
				if (args.Length > 0)
				{
					args.Append(@",");
					args.Append(@" ");
				}

				var variableName = property.VariableName;

				buffer.Append(@"var");
				buffer.Append(@" ");
				buffer.Append(variableName);
				buffer.Append(@" = ");
				var referenceEntityConfig = property.ReferenceEntityConfig;
				if (referenceEntityConfig != null)
				{
					buffer.Append(NameProvider.GetVariableName(referenceEntityConfig.ClassPluralName));
					buffer.Append(@"[");
				}
				ReadDbValue(buffer, property.Column, index++);
				if (referenceEntityConfig != null)
				{
					buffer.Append(@"]");
				}
				buffer.Append(@";");

				args.Append(variableName);
			}

			buffer.AppendLine();
			buffer.AppendLine();

			buffer.Append(@"return");
			buffer.Append(@" ");
			buffer.Append(@"new");
			buffer.Append(@" ");
			buffer.Append(className);
			buffer.Append(@"(");
			buffer.Append(args);
			buffer.Append(@")");
			buffer.Append(@";");

			return buffer.ToString();
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

#if !DEBUG
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
#endif
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