using System;
using System.Collections.Generic;

namespace AppCore.Localization
{
	//public interface ILocalization
	//{
	//	string GetValue(string key);

	//	void LoadValues(IEnumerable<KeyValuePair<string, string>> values);
	//}

	public interface ILocalization
	{
		string GetValue(string key);
	}

	public sealed class Localization : ILocalization
	{
		private Dictionary<string, string> Values { get; } = new Dictionary<string, string>();

		public string GetValue(string key)
		{
			this.Values.TryGetValue(key, out var value);
			return value ?? string.Empty;
		}

		public void LoadValues(IEnumerable<KeyValuePair<string, string>> values)
		{
			foreach (var kv in values)
			{
				this.Values.TryAdd(kv.Key, kv.Value);
			}
		}
	}
}