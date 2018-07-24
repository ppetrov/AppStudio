using System;

namespace AppStudio.Db
{
	public sealed class Table
	{
		public string Name { get; }
		public Column[] Columns { get; }

		public Table(string name, Column[] columns)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (columns == null) throw new ArgumentNullException(nameof(columns));

			this.Name = name;
			this.Columns = columns;
		}
	}
}