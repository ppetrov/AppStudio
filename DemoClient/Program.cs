using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using AppStudio.Config;
using AppStudio.Data;
using AppStudio.Db;
using AppStudio.Generators;
using AtosClient.Cache;

namespace DemoClient
{
	class Program
	{
		private static readonly Random Rnd = new Random();

		static void Main(string[] args)
		{
			var path = @"C:\Users\PetarPetrov\AppData\Local\Packages\9ed4bf97-9c34-45dc-a217-5f8121aa6dfc_7gbmn9e1bm2jj\LocalState\ifsa.sqlite";

			//path = @"C:\Users\PetarPetrov\Desktop\app_studio.sqlite";

			var projectConfig = new ProjectConfig();
			projectConfig.Add(new EntityConfig(@"ACTIVATION_COMPLIANCES"));
			// TODO : !!!
			//projectConfig.Load(null); // load to a file
			//projectConfig.Save(null); // save to a file

			var cnString = $@"Data Source = {path}; Version = 3; DateTimeFormat=Ticks;";

			var classes = new StringBuilder();
			var dataProvider = new StringBuilder();

			var register = new StringBuilder();

			using (var dbContext = new DbContext(cnString))
			{
				foreach (var table in DataProvider.GetTables(dbContext))
				{
					if (table.Name.Contains('$') ||
						table.Name.IndexOf(@"Asset_Class", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"open_balance", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"factory_cal", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"Visit_dat", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"Equipment", StringComparison.OrdinalIgnoreCase) >= 0 ||
						table.Name.IndexOf(@"Temp_data", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						continue;
					}


					var buffer = new StringBuilder(4 * 1024);

					buffer.Clear();
					CodeGenerator.GenerateClass(buffer, table, projectConfig);
					buffer.AppendLine();
					//CodeGenerator.GenerateCaptionsClass(buffer, table, projectConfig);
					//buffer.AppendLine();
					//CodeGenerator.GenerateViewModel(buffer, table, projectConfig);
					//buffer.AppendLine();
					//CodeGenerator.GeneratePropertyEnum(buffer, table, projectConfig);
					//buffer.AppendLine();
					//CodeGenerator.GenerateParametersClass(buffer, table, projectConfig);
					//buffer.AppendLine();
					//CodeGenerator.GenerateSortOptionsArray(buffer, table, projectConfig);
					//buffer.AppendLine();
					//CodeGenerator.GenerateSortOptionsProperties(buffer, table, projectConfig);
					//buffer.AppendLine();
					//CodeGenerator.GenerateSortOptionsInitialization(buffer, table, projectConfig);
					//buffer.AppendLine();
					//CodeGenerator.GenerateIsTextMatchMethod(buffer, table, projectConfig);
					//buffer.AppendLine();
					//CodeGenerator.GenerateSortMethod(buffer, table, projectConfig);
					//buffer.AppendLine();


					Console.WriteLine();
					Console.WriteLine(buffer.ToString());

					classes.AppendLine(buffer.ToString());

					buffer.Clear();
					CodeGenerator.GenerateGetAll(buffer, table, projectConfig);

					dataProvider.AppendLine(buffer.ToString());

					//register.AppendLine($@"Console.Write(""{table.Name}"" + "" : "");");
					//register.AppendLine($@"Console.WriteLine(DataProviders.Get{projectConfig.GetEntityConfig(table.Name).ClassPluralName}(dbContext, cache).Count);");

					register.AppendLine($@"s.Add(""{table.Name}"", DataProviders.Get{projectConfig.GetEntityConfig(table.Name).ClassPluralName}(dbContext, cache).Count);");
				}


				var cache = new DataCache();
				//cache.Register(DataProviders.GetBrandKinds);
				//cache.Register(DataProviders.GetBrands);
				//cache.Register(DataProviders.GetFlavours);
				//var arts = DataProviders.GetArticles(ctx, cache);
				//Console.WriteLine(arts.Count);

				var s = new Dictionary<string, int>();

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
			var data = dataProvider.ToString();
			//Console.WriteLine(code.Length);
			//Console.WriteLine(data.Length);

			foreach (var s in register.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
			{
				Debug.WriteLine(s);
			}

			//Console.WriteLine(code);
			//Console.WriteLine(data);
			//return;

			//			File.WriteAllText(@"C:\Atos\AppStudio\AppStudio\Objects.cs", string.Format(@"using System;
			//using AppCore.ViewModels;

			//namespace AppStudio
			//{{
			//	{0}
			//}}
			//", code));

			//			File.WriteAllText(@"C:\Atos\AppStudio\AppStudio\DataProviders.cs", string.Format(@"using System;
			//using System.Collections.Generic;
			//using AppCore;
			//using AppCore.Data;

			//namespace AppStudio
			//{{
			//	public static class DataProviders
			//	{{
			//		{0}
			//	}}
			//}}
			//", data));

		}

		private static void Display(int[] numbers, int count)
		{
			for (var i = 0; i < count; i++)
			{
				Console.WriteLine(numbers[i]);
			}
		}

		private static void CheckAllPages()
		{
			var folder = @"C:\Cchbc\PhoenixClient\iFSAXamarin\iFSA.MultiPlateform\iFSA.MultiPlateform";
			foreach (var file in Directory.GetFiles(folder, @"*.xaml", SearchOption.AllDirectories))
			{
				var contents = File.ReadAllText(file);
				var flag = @"<ContentPage";
				var startIndex = contents.IndexOf(flag, StringComparison.OrdinalIgnoreCase);
				if (startIndex >= 0)
				{
					var endIndex = contents.IndexOf(@">", startIndex + flag.Length + 1, StringComparison.OrdinalIgnoreCase);
					var definition = contents.Substring(startIndex, endIndex - startIndex + 1);
					if (definition.IndexOf("Padding", StringComparison.OrdinalIgnoreCase) < 0)
					{
						Console.WriteLine(Path.GetFileName(file));
						break;
					}
				}
			}
		}

		private static void Generate()
		{
			foreach (var val in DataGenerator.Generate(23, new Func<string>[]
			{
				DataGenerator.CustomerName,
				DataGenerator.CustomerNumber,
				DataGenerator.Address,
				DataGenerator.City,
				DataGenerator.PersonName,
				DataGenerator.Barcode,
				() =>
				{
					var powers = new[]
					{
						@"500",
						@"600",
						@"800",
						@"900",
						@"1000",
						@"1100",
						@"1200",
						@"1400",
						@"1600",
						@"2000",
						@"2500",
					};
					return powers[Rnd.Next(powers.Length)];
				}
			}))
			{
				foreach (var v in val)
				{
					Console.WriteLine(v);
				}
				Console.WriteLine();

				//Console.WriteLine(val);
			}
		}
	}
}
