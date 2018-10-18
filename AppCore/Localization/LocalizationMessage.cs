using System;

namespace AppCore.Localization
{
	public sealed class LocalizationMessage
	{
		public string Contents { get; }

		public LocalizationMessage(string contents)
		{
			if (contents == null) throw new ArgumentNullException(nameof(contents));

			this.Contents = contents;
		}
	}
}