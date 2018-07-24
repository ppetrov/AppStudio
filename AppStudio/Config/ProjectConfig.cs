using System;
using System.Collections.Generic;
using System.IO;

namespace AppStudio.Config
{
	public sealed class ProjectConfig
	{
		private Dictionary<string, EntityConfig> EntityConfigs { get; } = new Dictionary<string, EntityConfig>(StringComparer.OrdinalIgnoreCase);

		public void Add(EntityConfig config)
		{
			if (config == null) throw new ArgumentNullException(nameof(config));

			this.EntityConfigs.Add(config.TableName, config);
		}

		public EntityConfig GetEntityConfig(string tableName)
		{
			if (tableName == null) throw new ArgumentNullException(nameof(tableName));

			this.EntityConfigs.TryGetValue(tableName, out var config);

			return config ?? new EntityConfig(tableName);
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