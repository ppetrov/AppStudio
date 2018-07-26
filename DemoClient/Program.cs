using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using AppStudio;
using AppStudio.Config;
using AppStudio.Db;
using AppStudio.Generators;

namespace DemoClient
{
	class Program
	{
		static void Main(string[] args)
		{
			var path = @"C:\Users\PetarPetrov\AppData\Local\Packages\9ed4bf97-9c34-45dc-a217-5f8121aa6dfc_7gbmn9e1bm2jj\LocalState\ifsa.sqlite";

			path = @"C:\Users\PetarPetrov\Desktop\app_studio.sqlite";

			var projectConfig = new ProjectConfig();
			projectConfig.Add(new EntityConfig(@"ACTIVATION_COMPLIANCES"));
			// TODO : !!!
			//dbConfig.Load(null); // load to a file
			//dbConfig.Save(null); // save to a file

			var cnString = $@"Data Source = {path}; Version = 3;";

			var classes = new StringBuilder();
			var dataprovider = new StringBuilder();

			using (var ctx = new DbContext(cnString))
			{
				var tables = DataProvider.GetTables(ctx);

				foreach (var table in tables)
				{
					if (table.Name.Contains('$') ||
						table.Name.IndexOf(@"Asset_Class", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"open_bala", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"factory_cal", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"Visit_dat", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						continue;
					}

					Console.WriteLine(table.Name);
					foreach (var column in table.Columns)
					{
						var fk = string.Empty;
						if (column.ForeignKey != null)
						{
							fk = $@"{column.ForeignKey.TableName}({column.ForeignKey.ColumnName})";
						}
						Console.WriteLine("\t" + column.Name + @":" + column.Type + @" ->" + column.IsPrimaryKey + @", " + fk);
					}
					Console.WriteLine();

					var buffer = new StringBuilder();

					//var config = projectConfig.GetEntityConfig(table.Name);
					//Console.WriteLine(config.ClassName);
					//Console.WriteLine(config.ClassPluralName);
					//Console.WriteLine();

					//buffer.Clear();
					//SqlGenerator.Select(buffer, table, tableConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					//buffer.Clear();
					//SqlGenerator.Insert(buffer, table, tableConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					//buffer.Clear();
					//SqlGenerator.Update(buffer, table, tableConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					//buffer.Clear();
					//SqlGenerator.Delete(buffer, table, tableConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();



					buffer.Clear();
					CodeGenerator.GenerateClass(buffer, table, projectConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					classes.AppendLine(buffer.ToString());

					buffer.Clear();
					CodeGenerator.GenerateGetAll(buffer, table, projectConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					dataprovider.AppendLine(buffer.ToString());

					//code.AppendLine(buffer.ToString());
				}

				var cache = new DataCache();
				cache.Register(DataProviders.GetBrandKinds);
				cache.Register(DataProviders.GetBrands);
				cache.Register(DataProviders.GetFlavours);
				var arts = DataProviders.GetArticles(ctx, cache);
				Console.WriteLine(arts.Count);

				ctx.Complete();
			}

			var code = classes.ToString();
			var data = dataprovider.ToString();
			Console.WriteLine(code.Length);
			Console.WriteLine(data.Length);

			File.WriteAllText(@"C:\Atos\AppStudio\Objects.cs", string.Format(@"using System;

namespace AppStudio
{{
	{0}
}}
", code));

			File.WriteAllText(@"C:\Atos\AppStudio\DataProviders.cs", string.Format(@"using System;
using System.Collections.Generic;
using AppStudio.Data;

namespace AppStudio
{{
	public static class DataProviders
	{{
		{0}
	}}
}}
", data));



			//Console.WriteLine();
			//foreach (var t in DataProvider.AllTypes)
			//{
			//	Console.WriteLine(t);
			//}
		}


	}
}
