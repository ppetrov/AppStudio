namespace AppStudio.Clr
{
	public sealed class ClrProperty
	{
		public string Name { get; }
		public string Type { get; }
		public bool ReadOnly { get; }
		public AccessLevel AccessLevel { get; }
		public string Initializer { get; }
		public bool AsNotifyProperty { get; }

		public ClrProperty(string name, string type, bool readOnly = true, AccessLevel accessLevel = AccessLevel.Public, string initializer = "", bool asNotifyProperty = false)
		{
			this.Name = name;
			this.Type = type;
			this.ReadOnly = readOnly;
			this.AccessLevel = accessLevel;
			this.Initializer = initializer;
			this.AsNotifyProperty = asNotifyProperty;
		}
	}
}