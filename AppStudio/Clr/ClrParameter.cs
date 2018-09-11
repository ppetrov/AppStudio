using System;

namespace AppStudio.Clr
{
	public sealed class ClrParameter
	{
		public string Name { get; }
		public string Type { get; }

		public ClrParameter(string name, string type)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (type == null) throw new ArgumentNullException(nameof(type));

			this.Name = name;
			this.Type = type;
		}
	}
}