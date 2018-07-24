using System;

namespace AppStudio.Config
{
	public sealed class ClassConfig
	{
		public string TableName { get; }
		public string ClassName { get; }
		public bool AsReadOnly { get; set; } = true;

		public ClassConfig(string tableName, string className = null)
		{
			if (tableName == null) throw new ArgumentNullException(nameof(tableName));

			this.TableName = tableName;
			this.ClassName = className ?? NameProvider.GetClassName(tableName);
		}
	}
}