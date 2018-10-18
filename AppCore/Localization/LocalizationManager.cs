using System;
using System.Collections.Generic;

namespace AppCore.Localization
{
	/// <summary>
	/// Collection of all the localized messages in the application
	/// </summary>
	public sealed class LocalizationManager
	{
		private Dictionary<string, string> Values { get; } = new Dictionary<string, string>();

		/// <summary>
		/// Gets the localized contents for the given key
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string GetLocal(string key)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			this.Values.TryGetValue(key, out var value);

			return value ?? string.Empty;
		}

		/// <summary>
		/// Load the localized contents. If the collection contains duplicate keys only the first one will be used.
		/// </summary>
		/// <param name="values"></param>
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