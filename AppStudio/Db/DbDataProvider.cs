using System;
using System.Collections.Generic;
using System.Linq;
using AppStudio.Data;

namespace AppStudio.Db
{
	public static class DataProvider
	{
		public static Table[] GetTables(IDbContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));

			var tables = new List<Table>();

			var query = new Query<string>(@"SELECT NAME FROM SQLITE_MASTER WHERE TYPE='table' ORDER BY NAME", r => r.GetString(0));

			foreach (var name in context.Execute(query))
			{
				if (name.IndexOf(@"sqlite_sequence", StringComparison.OrdinalIgnoreCase) >= 0 ||
					name.IndexOf(@"installation_parameters", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					continue;
				}

				tables.Add(new Table(name, GetColumns(context, name)));
			}

			return tables.ToArray();
		}

		private static Column[] GetColumns(IDbContext context, string tableName)
		{
			var query = new Query<Column>($@"PRAGMA table_info('{tableName}')", r =>
			{
				var position = Query.GetLong(r, 0);
				var name = Query.GetString(r, 1);
				var type = Map(Query.GetString(r, 2));
				var isNullable = Query.GetLong(r, 3) == 0;
				// 4 is dflt_value - Skip it
				var isPrimaryKey = Query.GetLong(r, 5) == 1;
				return new Column(name, type, position, isNullable, isPrimaryKey);
			});

			var columns = context.Execute(query).ToArray();

			foreach (var fk in GetFKs(context, tableName))
			{
				var fkName = fk.Item1;
				for (var index = 0; index < columns.Length; index++)
				{
					var c = columns[index];
					if (c.Name.Equals(fkName, StringComparison.OrdinalIgnoreCase))
					{
						columns[index] = new Column(c.Name, c.Type, c.Position, c.IsNullable, c.IsPrimaryKey, fk.Item2);
						break;
					}
				}
			}

			return columns;
		}

		private static IEnumerable<Tuple<string, ForeignKey>> GetFKs(IDbContext context, string tableName)
		{
			var query = new Query<Tuple<string, ForeignKey>>($@"PRAGMA foreign_key_list('{tableName}')", r =>
			{
				var fkTable = Query.GetString(r, 2);
				var fkColumn = Query.GetString(r, 4);
				var column = Query.GetString(r, 3);

				return Tuple.Create(column, new ForeignKey(fkTable, fkColumn));
			});

			return context.Execute(query);
		}

		private static SqlDataType Map(string type)
		{
			var value = type.ToUpperInvariant();
			if (value.Equals(@"INT", StringComparison.OrdinalIgnoreCase))
			{
				return SqlDataType.Int;
			}
			if (value.Equals(@"DATETIME", StringComparison.OrdinalIgnoreCase))
			{
				return SqlDataType.DateTime;
			}
			if (value.Equals(@"BIGINT", StringComparison.OrdinalIgnoreCase) ||
				value.Equals(@"INTEGER", StringComparison.OrdinalIgnoreCase))
			{
				return SqlDataType.Long;
			}
			if (value.Equals(@"NUMERIC", StringComparison.OrdinalIgnoreCase))
			{
				return SqlDataType.Decimal;
			}
			if (value.Equals(@"BLOB", StringComparison.OrdinalIgnoreCase))
			{
				return SqlDataType.ByteArray;
			}
			if (value.Equals(@"GUID", StringComparison.OrdinalIgnoreCase))
			{
				return SqlDataType.Guid;
			}
			if (value.Equals(@"TEXT", StringComparison.OrdinalIgnoreCase) ||
				value.IndexOf(@"VARCHAR", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return SqlDataType.String;
			}
			throw new ArgumentOutOfRangeException(type, $@"Unsupported SqlDataType: '{type}'");
		}
	}
}