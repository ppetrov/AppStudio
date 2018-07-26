using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AppStudio.Db;

namespace AppStudio.Config
{
	public sealed class ProjectConfig
	{
		private Dictionary<string, EntityConfig> EntityConfigs { get; } = new Dictionary<string, EntityConfig>(StringComparer.OrdinalIgnoreCase);
		private Dictionary<string, EntityConfig[]> ReferenceEntitiesConfigs { get; } = new Dictionary<string, EntityConfig[]>(StringComparer.OrdinalIgnoreCase);

		public void Add(EntityConfig config)
		{
			if (config == null) throw new ArgumentNullException(nameof(config));

			this.EntityConfigs.Add(config.TableName, config);
		}

		public EntityConfig GetEntityConfig(string tableName)
		{
			if (tableName == null) throw new ArgumentNullException(nameof(tableName));

			if (!this.EntityConfigs.TryGetValue(tableName, out var config))
			{
				config = new EntityConfig(tableName);
				this.EntityConfigs.Add(tableName, config);
			}

			return config;
		}

		public EntityConfig[] GetReferenceEntityConfigs(string tableName)
		{
			if (tableName == null) throw new ArgumentNullException(nameof(tableName));

			this.ReferenceEntitiesConfigs.TryGetValue(tableName, out var configs);
			return configs;
		}

		public void Save(FileInfo filePath)
		{
			if (filePath == null) throw new ArgumentNullException(nameof(filePath));

		}

		public void Load(FileInfo filePath)
		{
			if (filePath == null) throw new ArgumentNullException(nameof(filePath));

		}

		public void LoadTables(IEnumerable<Table> tables)
		{
			if (tables == null) throw new ArgumentNullException(nameof(tables));

			var emptyConfigs = Enumerable.Empty<EntityConfig>().ToArray();

			this.ReferenceEntitiesConfigs.Clear();

			foreach (var table in tables)
			{
				var entityConfigs = default(List<EntityConfig>);

				foreach (var column in table.Columns)
				{
					var fk = column.ForeignKey;
					if (fk != null)
					{
						if (entityConfigs == null)
						{
							entityConfigs = new List<EntityConfig>();
						}
						entityConfigs.Add(this.GetEntityConfig(fk.TableName));
					}
				}

				var configs = emptyConfigs;
				if (entityConfigs != null)
				{
					configs = entityConfigs.ToArray();
				}

				this.ReferenceEntitiesConfigs.Add(table.Name, configs);
			}
		}
	}
}