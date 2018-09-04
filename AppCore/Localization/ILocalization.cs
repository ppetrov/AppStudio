using System.Collections.Generic;

namespace AppCore.Localization
{
	public interface ILocalization
	{
		string GetValue(string key);

		void LoadValues(IEnumerable<KeyValuePair<string, string>> values);
	}	
}