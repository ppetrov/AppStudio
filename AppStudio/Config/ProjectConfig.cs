using System;
using System.Collections.Generic;
using System.IO;

namespace AppStudio.Config
{
	public sealed class ProjectConfig
	{
		private Dictionary<string, TableConfig> TableConfigs { get; } = new Dictionary<string, TableConfig>(StringComparer.OrdinalIgnoreCase);
		private Dictionary<string, ClassConfig> ClassConfigs { get; } = new Dictionary<string, ClassConfig>(StringComparer.OrdinalIgnoreCase);

		public void AddTableConfig(TableConfig config)
		{
			if (config == null) throw new ArgumentNullException(nameof(config));

			this.TableConfigs.Add(config.TableName, config);
		}

		public void AddClassConfig(ClassConfig config)
		{
			if (config == null) throw new ArgumentNullException(nameof(config));

			this.ClassConfigs.Add(config.TableName, config);
		}

		public TableConfig GetTableConfig(string tableName)
		{
			if (tableName == null) throw new ArgumentNullException(nameof(tableName));

			this.TableConfigs.TryGetValue(tableName, out var config);

			return config ?? new TableConfig(tableName);
		}

		public ClassConfig GetClassConfig(string tableName)
		{
			if (tableName == null) throw new ArgumentNullException(nameof(tableName));

			this.ClassConfigs.TryGetValue(tableName, out var config);

			return config ?? new ClassConfig(tableName);
		}

		public void Save(FileInfo filePath)
		{
			if (filePath == null) throw new ArgumentNullException(nameof(filePath));

		}

		public void Load(FileInfo filePath)
		{
			if (filePath == null) throw new ArgumentNullException(nameof(filePath));

		}
	}
}