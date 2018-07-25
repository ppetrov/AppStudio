using System;

namespace AppStudio.Db
{
	public sealed class ForeignKey
	{
		public string TableName { get; }
		public string ColumnName { get; }

		public ForeignKey(string tableName, string columnName)
		{
			if (tableName == null) throw new ArgumentNullException(nameof(tableName));
			if (columnName == null) throw new ArgumentNullException(nameof(columnName));

			this.TableName = tableName;
			this.ColumnName = columnName;
		}
	}
}