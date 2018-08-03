﻿using System;

namespace AppCore.Features
{
	public sealed class Feature
	{
		public string Context { get; }
		public string Name { get; }

		public Feature(string context, string name)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));
			if (name == null) throw new ArgumentNullException(nameof(name));

			this.Context = context;
			this.Name = name;
		}
	}
}