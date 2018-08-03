using System;

namespace AppCore.Sort
{
	public sealed class SortOption
	{
		public string Name { get; }
		public object Data { get; }

		public SortDirection? SortDirection { get; set; }

		public SortOption(string name, object data)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));

			this.Name = name;
			this.Data = data;
		}
	}
}