using System;
using System.Text;
using AppStudio.Config;
using AppStudio.Db;

namespace AppStudio.Generators
{
	public static class SqlGenerator
	{
		public static void GenerateSelect(StringBuilder buffer, Table table, TableConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			buffer.Append(@"SELECT");
			buffer.Append(@" ");

			var addComma = false;
			foreach (var column in config.GetSelectColumns(table.Columns))
			{
				if (addComma)
				{
					buffer.Append(',');
					buffer.Append(@" ");
				}
				buffer.Append(column.Name);
				addComma = true;
			}

			buffer.Append(@" ");
			buffer.Append(@"FROM");
			buffer.Append(@" ");
			buffer.Append(table);
		}
	}
}