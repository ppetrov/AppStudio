using System;
using System.Collections.Generic;

namespace AppCore.Localization
{
	public sealed class LocalizationManager
	{
		private Dictionary<string, string> Values { get; } = new Dictionary<string, string>();

		public string GetMessage(string key)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			this.Values.TryGetValue(key, out var value);
			return value ?? string.Empty;
		}

		public void Load(IEnumerable<KeyValuePair<string, string>> values)
		{
			if (values == null) throw new ArgumentNullException(nameof(values));

			this.Values.Clear();
			foreach (var kv in values)
			{
				this.Values.TryAdd(kv.Key, kv.Value);
			}
		}
	}
}