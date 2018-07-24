using System;
using AppStudio.Db;

namespace AppStudio
{
	public sealed class Column
	{
		public string Name { get; }
		public SqlDataType Type { get; }
		public long Position { get; }
		public bool IsNullable { get; }
		public bool IsPrimaryKey { get; }

		public Column(string name, SqlDataType type, long position, bool isNullable, bool isPrimaryKey)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));

			this.Name = name;
			this.Type = type;
			this.Position = position;
			this.IsNullable = isNullable;
			this.IsPrimaryKey = isPrimaryKey;
		}
	}
}