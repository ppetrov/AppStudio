using System;

namespace AppStudio.Clr
{
	public sealed class EnumEntry
	{
		public string Name { get; }

		public EnumEntry(string name)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));

			this.Name = name;
		}
	}
}