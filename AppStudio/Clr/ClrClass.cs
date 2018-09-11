using System;
using System.Collections.Generic;

namespace AppStudio.Clr
{
	public sealed class ClrClass
	{
		public string Name { get; }
		public List<ClrProperty> Properties { get; }
		public List<ClrMethod> Methods { get; }

		public ClrClass(string name)
		{
			this.Name = name;
			this.Properties = new List<ClrProperty>(0);
			this.Methods = new List<ClrMethod>(0);
		}

		public ClrClass(string name, List<ClrProperty> properties, List<ClrMethod> methods)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (properties == null) throw new ArgumentNullException(nameof(properties));
			if (methods == null) throw new ArgumentNullException(nameof(methods));

			this.Name = name;
			this.Properties = properties;
			this.Methods = methods;
		}
	}
}