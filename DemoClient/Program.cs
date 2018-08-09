using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using AppCore;
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
			//projectConfig.Load(null); // load to a file
			//projectConfig.Save(null); // save to a file



			var cnString = $@"Data Source = {path}; Version = 3; DateTimeFormat=Ticks;";

			var classes = new StringBuilder();
			var dataprovider = new StringBuilder();

			var register = new StringBuilder();

			using (var dbContext = new DbContext(cnString))
			{
				var tables = DataProvider.GetTables(dbContext);

				foreach (var table in tables)
				{
					if (table.Name.Contains('$') ||
						table.Name.IndexOf(@"Asset_Class", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"open_bala", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"factory_cal", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"Visit_dat", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"Temp_data", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						continue;
					}
					if (table.Name.IndexOf(@"Equipment", StringComparison.OrdinalIgnoreCase) < 0)
					{
						continue;
					}

					//Console.WriteLine(table.Name);
					//foreach (var column in table.Columns)
					//{
					//	var fk = string.Empty;
					//	if (column.ForeignKey != null)
					//	{
					//		fk = $@"{column.ForeignKey.TableName}({column.ForeignKey.ColumnName})";
					//	}
					//	Console.WriteLine("\t" + column.Name + @":" + column.Type + @" ->" + column.IsPrimaryKey + @", " + fk);
					//}
					//Console.WriteLine();

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
					//CodeGenerator.GenerateClass(buffer, table, projectConfig);
					//buffer.AppendLine();
					//CodeGenerator.GenerateCaptionsClass(buffer, table, projectConfig);
					//buffer.AppendLine();
					//CodeGenerator.GenerateViewModel(buffer, table, projectConfig);
					buffer.AppendLine();
					CodeGenerator.GeneratePropertyEnum(buffer, table, projectConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					classes.AppendLine(buffer.ToString());

					buffer.Clear();
					CodeGenerator.GenerateGetAll(buffer, table, projectConfig);
					//Console.WriteLine(buffer.ToString());
					//Console.WriteLine();

					dataprovider.AppendLine(buffer.ToString());


					//register.AppendLine($@"Console.Write(""{table.Name}"" + "" : "");");
					//register.AppendLine($@"Console.WriteLine(DataProviders.Get{projectConfig.GetEntityConfig(table.Name).ClassPluralName}(dbContext, cache).Count);");


					register.AppendLine($@"s.Add(""{table.Name}"", DataProviders.Get{projectConfig.GetEntityConfig(table.Name).ClassPluralName}(dbContext, cache).Count);");

					//code.AppendLine(buffer.ToString());
				}


				var cache = new DataCache();
				//cache.Register(DataProviders.GetBrandKinds);
				//cache.Register(DataProviders.GetBrands);
				//cache.Register(DataProviders.GetFlavours);
				//var arts = DataProviders.GetArticles(ctx, cache);
				//Console.WriteLine(arts.Count);

				var s = new Dictionary<string, int>();

				//s.Add("ACTIVATION_COMPLIANCES", DataProviders.GetActivationCompliances(dbContext, cache).Count);

				var vals = s
					.Where(v => v.Value != 0)
					.Select(v => Tuple.Create(v.Key, v.Value))
					.ToList();
				vals.Sort((x, y) =>
					{
						var cmp = y.Item2.CompareTo(x.Item2);
						if (cmp == 0)
						{
							cmp = string.Compare(x.Item1, y.Item1, StringComparison.OrdinalIgnoreCase);
						}
						return cmp;
					}
				);

				foreach (var v in vals)
				{
					Console.WriteLine(v);
				}


				dbContext.Complete();
			}

			var code = classes.ToString();
			var data = dataprovider.ToString();
			//Console.WriteLine(code.Length);
			//Console.WriteLine(data.Length);

			foreach (var s in register.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
			{
				Debug.WriteLine(s);
			}


			//Console.WriteLine(code);
			Console.WriteLine(data);
			return;

			File.WriteAllText(@"C:\Atos\AppStudio\AppStudio\Objects.cs", string.Format(@"using System;
using AppCore.ViewModels;

namespace AppStudio
{{
	{0}
}}
", code));

			File.WriteAllText(@"C:\Atos\AppStudio\AppStudio\DataProviders.cs", string.Format(@"using System;
using System.Collections.Generic;
using AppCore;
using AppCore.Data;

namespace AppStudio
{{
	public static class DataProviders
	{{
		{0}
	}}
}}
", data));

		}


	}
}
