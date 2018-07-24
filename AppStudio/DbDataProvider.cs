using System;
using System.Collections.Generic;
using System.Linq;
using AppStudio.Db;
using AppStudio.Db.Data;

namespace AppStudio
{
	public static class DbDataProvider
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

		public static Column[] GetColumns(IDbContext context, string tableName)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));
			if (tableName == null) throw new ArgumentNullException(nameof(tableName));

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

			return context.Execute(query).ToArray();
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