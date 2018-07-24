using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppStudio.Config;
using AppStudio.Db;

namespace AppStudio.Generators
{
	public static class SqlGenerator
	{
		public static void Select(StringBuilder buffer, Table table, TableConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			buffer.Append(@"SELECT");
			buffer.Append(@" ");
			AddColumns(buffer, config.GetSelectColumns(table.Columns));
			buffer.Append(@" ");
			buffer.Append(@"FROM");
			buffer.Append(@" ");
			buffer.Append(table.Name);
		}

		public static void Insert(StringBuilder buffer, Table table, TableConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			buffer.Append(@"INSERT");
			buffer.Append(@" ");
			buffer.Append(@"INTO");
			buffer.Append(@" ");
			buffer.Append(table.Name);
			buffer.AppendLine();
			buffer.Append('\t');
			buffer.Append(@"(");
			AddColumns(buffer, table.Columns);
			buffer.Append(@")");
			buffer.AppendLine();
			buffer.Append(@"VALUES");
			buffer.AppendLine();
			buffer.Append('\t');
			buffer.Append(@"(");
			AddParameters(buffer, table.Columns);
			buffer.Append(@")");
		}

		public static void Update(StringBuilder buffer, Table table, TableConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			buffer.Append(@"UPDATE");
			buffer.Append(@" ");
			buffer.Append(table.Name);
			buffer.AppendLine();
			buffer.Append(@"SET");
			buffer.AppendLine();
			AddColumnToParamAssignment(buffer, table.Columns.Where(c => !c.IsPrimaryKey));
			buffer.AppendLine();
			buffer.Append(@"WHERE");
			buffer.AppendLine();
			AddColumnToParamAssignment(buffer, table.Columns.Where(c => c.IsPrimaryKey));
		}

		public static void Delete(StringBuilder buffer, Table table, TableConfig config)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (table == null) throw new ArgumentNullException(nameof(table));
			if (config == null) throw new ArgumentNullException(nameof(config));

			buffer.Append(@"DELETE");
			buffer.Append(@" ");
			buffer.Append(@"FROM");
			buffer.Append(@" ");
			buffer.Append(table.Name);
			buffer.AppendLine();
			buffer.Append(@"WHERE");
			buffer.AppendLine();
			AddColumnToParamAssignment(buffer, table.Columns.Where(c => c.IsPrimaryKey));
		}

		private static void AddColumns(StringBuilder buffer, IEnumerable<Column> columns)
		{
			Add(buffer, columns, (b, c) => b.Append(c.Name));
		}

		private static void AddParameters(StringBuilder buffer, IEnumerable<Column> columns)
		{
			Add(buffer, columns, AddParameter);
		}

		private static void Add(StringBuilder buffer, IEnumerable<Column> columns, Action<StringBuilder, Column> appender)
		{
			var addComma = false;
			foreach (var column in columns)
			{
				if (addComma)
				{
					buffer.Append(@",");
					buffer.Append(@" ");
				}

				appender(buffer, column);
				addComma = true;
			}
		}

		private static void AddColumnToParamAssignment(StringBuilder buffer, IEnumerable<Column> columns)
		{
			var addComma = false;
			foreach (var column in columns)
			{
				if (addComma)
				{
					buffer.Append(@",");
					buffer.AppendLine();
				}

				buffer.Append('\t');
				buffer.Append(column.Name);
				buffer.Append(@" = ");
				AddParameter(buffer, column);
				addComma = true;
			}
		}

		private static void AddParameter(StringBuilder buffer, Column column)
		{
			buffer.Append(@"@p");
			buffer.Append(NameProvider.GetPropertyName(column.Name));
		}
	}
}