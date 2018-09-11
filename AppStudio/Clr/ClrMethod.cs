using System;
using System.Collections.Generic;

namespace AppStudio.Clr
{
	public sealed class ClrMethod
	{
		public AccessLevel AccessLevel { get; }
		public string Name { get; }
		public List<ClrParameter> Parameters { get; }
		public string ReturnType { get; }

		public ClrMethod(string name, List<ClrParameter> parameters, string returnType, AccessLevel accessLevel = AccessLevel.Public)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (parameters == null) throw new ArgumentNullException(nameof(parameters));
			if (returnType == null) throw new ArgumentNullException(nameof(returnType));

			this.Name = name;
			this.Parameters = parameters;
			this.ReturnType = returnType;
			this.AccessLevel = accessLevel;
		}
	}
}