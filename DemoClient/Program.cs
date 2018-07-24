using System;
using System.Data.SQLite;
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

			var projectConfig = new ProjectConfig();
			projectConfig.AddTableConfig(new TableConfig(@"ACTIVATION_COMPLIANCES"));
			projectConfig.AddClassConfig(new ClassConfig(@"ACTIVATION_COMPLIANCES", @"ActivationCompliance"));
			// TODO : !!!
			//dbConfig.Load(null); // load to a file
			//dbConfig.Save(null); // save to a file

			var cnString = $@"Data Source = {path}; Version = 3;";


			var code = new StringBuilder();

			using (var ctx = new DbContext(cnString))
			{
				var tables = DataProvider.GetTables(ctx);

				foreach (var table in tables.Take(1))
				{
					//Console.WriteLine(table.Name + @" -> " + table.Columns.Length);
					//foreach (var column in table.Columns)
					//{
					//	Console.WriteLine("\t" + column.Name + @":" + column.Type + @" ->" + column.IsPrimaryKey);
					//}
					//Console.WriteLine();

					var buffer = new StringBuilder();

					var tableConfig = projectConfig.GetTableConfig(table.Name);

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
					CodeGenerator.GenerateClass(buffer, table, projectConfig.GetClassConfig(table.Name), tableConfig);
					Console.WriteLine(buffer.ToString());
					Console.WriteLine();

					buffer.Clear();
					CodeGenerator.GenerateGetAll(buffer, table, projectConfig.GetClassConfig(table.Name), tableConfig);
					Console.WriteLine(buffer.ToString());
					Console.WriteLine();

					code.AppendLine(buffer.ToString());
				}
				ctx.Complete();
			}

			//var t = code.ToString();
			//Console.WriteLine(t.Length);



			//Console.WriteLine();
			//foreach (var t in DataProvider.AllTypes)
			//{
			//	Console.WriteLine(t);
			//}
		}
	}
}
