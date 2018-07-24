using System;
using System.Collections.Generic;

namespace AppStudio.Config
{
	public sealed class EntityConfig
	{
		public string TableName { get; }
		public string ClassName { get; set; }
		public string ClassPluralName { get; set; } = string.Empty;
		public bool AsReadOnly { get; set; } = true;

		public EntityConfig(string tableName, string className = null, string classPluralName = null)
		{
			if (tableName == null) throw new ArgumentNullException(nameof(tableName));

			this.TableName = tableName;
			this.ClassName = className ?? NameProvider.GetClassName(tableName);
			this.ClassPluralName = classPluralName ?? this.ClassName + @"s";
		}

		public IEnumerable<Column> GetSelectColumns(Column[] columns)
		{
			if (columns == null) throw new ArgumentNullException(nameof(columns));

			foreach (var column in columns)
			{
				if (!column.Name.Equals(@"REC_STATUS", StringComparison.OrdinalIgnoreCase))
				{
					yield return column;
				}
			}
		}
	}
}