using System;
using System.Text;

namespace AppStudio
{
	public static class NameProvider
	{
		public static string GetClassName(string value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));

			return GetName(value, true);
		}

		public static string GetPropertyName(string value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));

			return GetName(value);
		}

		public static string GetVariableName(string value)
		{
			return char.ToLowerInvariant(value[0]) + value.Substring(1);
		}

		private static string GetName(string value, bool removeTrailingS = false)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));

			var buffer = new StringBuilder(value.Length);

			buffer.Append(char.ToUpperInvariant(value[0]));

			var toUpper = false;
			for (var i = 1; i < value.Length; i++)
			{
				var symbol = value[i];
				if (symbol == '_')
				{
					toUpper = true;
					continue;
				}

				symbol = char.ToLowerInvariant(symbol);
				if (toUpper)
				{
					symbol = char.ToUpperInvariant(symbol);
				}

				buffer.Append(symbol);
				toUpper = false;
			}

			if (removeTrailingS)
			{
				if (char.ToLowerInvariant(buffer[buffer.Length - 1]) == 's')
				{
					buffer.Remove(buffer.Length - 1, 1);
				}
			}

			return buffer.ToString();
		}
	}
}