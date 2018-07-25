using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AppStudio.Db;

namespace AppStudio.Config
{
	public sealed class ProjectConfig
	{
		public Table[] Tables { get; set; }

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




		public EntityConfig[] GetReferenceEntityConfigs(Table table)
		{
			if (table == null) throw new ArgumentNullException(nameof(table));

			var fkCount = GetForeignKeyCount(table);
			if (fkCount == 0)
			{
				return Enumerable.Empty<EntityConfig>().ToArray();
			}

			var index = 0;
			var referenceTables = new EntityConfig[fkCount];

			foreach (var c in table.Columns)
			{
				var fk = c.ForeignKey;
				if (fk != null)
				{
					var referenceTable = GetTable(this.Tables, fk.TableName);					
					referenceTables[index++] = this.GetEntityConfig(referenceTable.Name);
				}
			}

			return referenceTables.ToArray();
		}

		private static int GetForeignKeyCount(Table table)
		{
			var count = 0;

			foreach (var column in table.Columns)
			{
				if (column.ForeignKey != null)
				{
					count++;
				}
			}

			return count;
		}

		private static Table GetTable(Table[] tables, string name)
		{
			foreach (var t in tables)
			{
				if (t.Name == name)
				{
					return t;
				}
			}
			return null;
		}
	}
}