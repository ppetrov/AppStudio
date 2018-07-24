using System;
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
			buffer.Append("\t");
			buffer.Append(@"(");
			var addComma = false;
			foreach (var column in table.Columns)
			{
				if (addComma)
				{
					buffer.Append(',');
					buffer.Append(@" ");
				}
				buffer.Append(column.Name);
				addComma = true;
			}
			buffer.Append(@")");
			buffer.AppendLine();
			buffer.Append(@"VALUES");
			buffer.AppendLine();
			buffer.Append('\t');
			buffer.Append(@"(");
			addComma = false;
			foreach (var column in table.Columns)
			{
				if (addComma)
				{
					buffer.Append(',');
					buffer.Append(@" ");
				}
				AddParameter(buffer, column);
				addComma = true;
			}
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

			var addComma = false;
			foreach (var column in table.Columns)
			{
				if (column.IsPrimaryKey) continue;
				if (addComma)
				{
					buffer.Append(',');
					buffer.AppendLine();
				}
				buffer.Append('\t');
				buffer.Append(column.Name);
				buffer.Append(@" = ");
				AddParameter(buffer, column);
				addComma = true;
			}

			buffer.AppendLine();
			buffer.Append(@"WHERE");
			buffer.AppendLine();

			addComma = false;
			foreach (var column in table.Columns)
			{
				if (!column.IsPrimaryKey) continue;
				if (addComma)
				{
					buffer.Append(',');
					buffer.AppendLine();
				}
				buffer.Append('\t');
				buffer.Append(column.Name);
				buffer.Append(@" = ");
				AddParameter(buffer, column);
				addComma = true;
			}

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

			var addComma = false;
			foreach (var column in table.Columns)
			{
				if (!column.IsPrimaryKey) continue;
				if (addComma)
				{
					buffer.Append(',');
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
			buffer.Append('@');
			buffer.Append('p');
			buffer.Append(NameProvider.GetVariableName(NameProvider.GetPropertyName(column.Name)));
		}
	}
}