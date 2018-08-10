using System;
using System.Collections.Generic;
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

		private static readonly string[] Cities =
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

		private static readonly string[] Names = {
			@"Pizza", @"Cafe", @"Restaurant", @"Kiosk", @"Stand", @"Shop", @"Champion",
			@"Magazine", @"Market", @"Land", @"Universe", @"Infinity", @"Smart", @"Gift", @"Winter",
			@"Unlimited", @"Luxury", @"No Limit", @"Priceless", @"Million", @"Winner", @"Summer"
		};

		public static IEnumerable<string[]> Generate(int count, Func<string>[] generators)
		{
			if (generators == null) throw new ArgumentNullException(nameof(generators));

			for (var i = 0; i < count; i++)
			{
				var values = new string[generators.Length];

				for (var index = 0; index < generators.Length; index++)
				{
					values[index] = generators[index]();
				}

				yield return values;
			}
		}

		public static string PersonName()
		{
			var first = FirstNames[Rnd.Next(FirstNames.Length)];
			var last = LastNames[Rnd.Next(LastNames.Length)];

			return first + @" " + last;
		}

		public static string City()
		{
			return Cities[Rnd.Next(Cities.Length)];
		}

		public static string Phone()
		{
			var buffer = new StringBuilder(12);

			for (var j = 0; j < buffer.Capacity; j++)
			{
				buffer.Append(Digits[Rnd.Next(Digits.Length)]);
			}

			buffer[3] = buffer[7] = '-';

			return buffer.ToString();
		}

		public static string Barcode()
		{
			var length = 13;

			var buffer = new StringBuilder(length);

			for (var j = 0; j < length - 1; j++)
			{
				buffer.Append(Digits[Rnd.Next(Digits.Length)]);
			}

			return buffer.ToString();
		}

		public static string Number(int min, int max)
		{
			return Rnd.Next(min, max + 1).ToString();
		}

		public static string Address()
		{
			var number = Rnd.Next(1, 168);
			var street = Steets[Rnd.Next(Steets.Length)];

			return number + @" " + street;
		}

		public static string CustomerName()
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

			var brand = string.Format(templates[Rnd.Next(templates.Length)], Names[Rnd.Next(Names.Length)]);

			if (Rnd.Next(8) == 0)
			{
				brand += @" - " + Rnd.Next(2, 38);
			}

			return brand;
		}

		public static string CustomerNumber()
		{
			var length = 10;

			var buffer = new StringBuilder(length);

			// First number can't be zero
			buffer.Append(Digits[Rnd.Next(1, Digits.Length)]);

			for (var i = 1; i < length - 1; i++)
			{
				buffer.Append(Digits[Rnd.Next(Digits.Length)]);
			}

			return buffer.ToString();
		}
	}
}