using System;
using System.Collections.Generic;

namespace AppStudio.Clr
{
	public sealed class ClrInterface
	{
		public AccessLevel AccessLevel { get; }
		public string Name { get; }
		public List<ClrProperty> Properties { get; }
		public List<ClrMethod> Methods { get; }

		public ClrInterface(string name, List<ClrProperty> properties = null, List<ClrMethod> methods = null, AccessLevel accessLevel = AccessLevel.Public)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			
			this.Name = name;
			this.AccessLevel = accessLevel;
			this.Properties = properties ?? new List<ClrProperty>(0);
			this.Methods = methods ?? new List<ClrMethod>(0);
		}
	}
}