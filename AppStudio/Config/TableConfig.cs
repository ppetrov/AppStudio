using System;
using System.Collections.Generic;

namespace AppStudio.Config
{
	public sealed class TableConfig
	{
		public string TableName { get; }
		private HashSet<string> ExcludedSelectColumns { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		public TableConfig(string tableName, bool excludeRecStatusFromSelect = true)
		{
			if (tableName == null) throw new ArgumentNullException(nameof(tableName));

			this.TableName = tableName;

			if (excludeRecStatusFromSelect)
			{
				this.ExcludeFromSelect(@"REC_STATUS");
			}
		}

		public void ExcludeFromSelect(string column)
		{
			if (column == null) throw new ArgumentNullException(nameof(column));

			this.ExcludedSelectColumns.Add(column);
		}

		public IEnumerable<Column> GetSelectColumns(IEnumerable<Column> columns)
		{
			if (columns == null) throw new ArgumentNullException(nameof(columns));

			foreach (var c in columns)
			{
				if (this.ExcludedSelectColumns.Count == 0 ||
					!this.ExcludedSelectColumns.Contains(c.Name))
				{
					yield return c;
				}
			}
		}
	}
}