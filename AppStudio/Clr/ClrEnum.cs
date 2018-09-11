using System;
using System.Collections.Generic;

namespace AppStudio.Clr
{
	public sealed class ClrEnum
	{
		public AccessLevel AccessLevel { get; }

		public string Name { get; }
		public List<EnumEntry> Entries { get; }

		public ClrEnum(string name, List<EnumEntry> entries, AccessLevel accessLevel = AccessLevel.Public)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (entries == null) throw new ArgumentNullException(nameof(entries));

			this.Name = name;
			this.AccessLevel = accessLevel;
			this.Entries = entries;
		}
	}
}