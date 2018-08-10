using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppStudio.Data
{
	public static class DataGenerator
	{
		private static readonly Random Rnd = new Random();

		private static readonly string[] FirstNames =
		{
			@"Alfred",
			@"Shayne",
			@"Marvin",
			@"Barney",
			@"Casper",
			@"Alexander",
			@"Naomi",
			@"Brooklyn",
			@"Kate",
			@"Cynthia",
			@"Maryon",
			@"Joan",
			@"Beatrix",
			@"Charlotte",
			@"Christina",
			@"Lindsey",
			@"Ted",
		};

		private static readonly string[] LastNames =
		{
			@"Harrison",
			@"Oliver",
			@"Baker",
			@"Wilson",
			@"Black",
			@"White",
			@"Edwards",
			@"Palmer",
			@"Lawrence",
			@"Cooper",
			@"Jackson",
			@"Smith",
			@"Campbell",
			@"Robertson",
			@"Johnston",
			@"Hamilton",
			@"Moore",
		};

		private static readonly string[] PredefinedCities =
		{
			@"London",
			@"Edinburgh",
			@"Birmingham",
			@"Manchester",
			@"Liverpool",
			@"Bristol",
			@"Glasgow",
			@"Leeds",
			@"Oxford",
			@"Cambridge",
			@"Brighton",
			@"York",
			@"Cardiff",
		};

		private static readonly string[] Steets =
		{
			@"Bedfont Lane",
			@"Hodson St",
			@"Spalding Rd",
			@"Fir Park",
			@"Long Acre",
			@"Furzton Lake",
			@"Eden Avenue",
			@"Dew St",
			@"Beechwood Avenue",
			@"Maybole Rd",
			@"The Broadway",
			@"Coney St",
			@"High Street",
			@"Park Avenue",
			@"Brookside Court",
			@"Rope Lane",
			@"Furness Park Rd",
			@"Heysham Avenue",
			@"Victoria Avenue",
			@"Croslands Park",
		};

		private static readonly string[] Digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

		private static readonly string[] PredefinedCustomerNames = new[]
		{
			@"Pizza", @"Cafe", @"Restaurant", @"Kiosk", @"Stand", @"Shop", @"Champion",
			@"Magazine", @"Market", @"Land", @"Universe", @"Infinity", @"Smart", @"Gift", @"Winter",
			@"Unlimited", @"Luxury", @"No Limit", @"Priceless", @"Million", @"Winner", @"Summer"
		};

		public static IEnumerable<string[]> Generate(int count, Func<int, IEnumerable<string>>[] generators)
		{
			if (generators == null) throw new ArgumentNullException(nameof(generators));

			for (var i = 0; i < count; i++)
			{
				var values = new string[generators.Length];

				for (var index = 0; index < generators.Length; index++)
				{
					values[index] = generators[index](1).Single();
				}

				yield return values;
			}
		}

		public static IEnumerable<string> PersonNames(int count = 1)
		{
			for (var i = 0; i < count; i++)
			{
				var first = FirstNames[Rnd.Next(FirstNames.Length)];
				var last = LastNames[Rnd.Next(LastNames.Length)];

				yield return first + @" " + last;
			}
		}

		public static IEnumerable<string> Cities(int count = 1)
		{
			for (var i = 0; i < count; i++)
			{
				var city = PredefinedCities[Rnd.Next(PredefinedCities.Length)];

				yield return city;
			}
		}

		public static IEnumerable<string> Phones(int count = 1)
		{
			for (var i = 0; i < count; i++)
			{
				var buffer = new StringBuilder(12);

				for (var j = 0; j < buffer.Capacity; j++)
				{
					buffer.Append(Digits[Rnd.Next(Digits.Length)]);
				}

				buffer[3] = buffer[7] = '-';

				yield return buffer.ToString();
			}
		}

		public static IEnumerable<string> Barcodes(int count = 1)
		{
			return Numbers(count, 13);
		}

		public static IEnumerable<string> Numbers(int count, int length = 10)
		{
			for (var i = 0; i < count; i++)
			{
				var buffer = new StringBuilder(length);

				buffer.Append(Digits[Rnd.Next(1, Digits.Length)]);

				for (var j = 0; j < length - 1; j++)
				{
					buffer.Append(Digits[Rnd.Next(Digits.Length)]);
				}

				yield return buffer.ToString();
			}
		}

		public static IEnumerable<string> Numbers(int count, int min, int max)
		{
			for (var i = 0; i < count; i++)
			{
				yield return Rnd.Next(min, max + 1).ToString();
			}
		}

		public static IEnumerable<string> Addresses(int count)
		{
			for (var i = 0; i < count; i++)
			{
				var number = Rnd.Next(1, 168);
				var street = Steets[Rnd.Next(Steets.Length)];

				yield return number + @" " + street;
			}
		}

		public static IEnumerable<string> CustomerNames(int count = 1)
		{
			for (var i = 0; i < count; i++)
			{
				var name = PredefinedCustomerNames[Rnd.Next(PredefinedCustomerNames.Length)];

				yield return GenerateCustomerNames(name);
			}
		}

		public static IEnumerable<string> CustomerNumbers(int count = 1)
		{
			return Numbers(count);
		}

		private static string GenerateCustomerNames(string name)
		{
			var templates = new[]
			{
				@"HappyLife {0}",
				@"{0} Station",
				@"ProStar {0}",
				@"Star {0}",
				@"{0} Gem",
				@"Zap {0}",
				@"Ninja {0}",
				@"Bonita {0}",
				@"{0} Shine",
				@"LowPrice {0}",
				@"Century {0}",
				@"{0} Bomb",
				@"Top {0}",
				@"Supreme {0}",
			};

			var brand = string.Format(templates[Rnd.Next(templates.Length)], name);

			if (Rnd.Next(8) == 0)
			{
				brand += @" - " + Rnd.Next(2, 38);
			}

			return brand;
		}
	}
}