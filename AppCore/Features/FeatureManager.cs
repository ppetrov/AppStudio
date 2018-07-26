using System;

namespace AppCore.Features
{
	public sealed class FeatureManager
	{
		public bool IsEnabled { get; set; } = true;

		public void Save(IFeatureDataAdapter adapter, Feature feature)
		{
			if (adapter == null) throw new ArgumentNullException(nameof(adapter));
			if (feature == null) throw new ArgumentNullException(nameof(feature));

			if (this.IsEnabled)
			{
				adapter.Insert(feature, string.Empty);
			}
		}

		public void Save(IFeatureDataAdapter adapter, Feature feature, Exception exception)
		{
			if (adapter == null) throw new ArgumentNullException(nameof(adapter));
			if (feature == null) throw new ArgumentNullException(nameof(feature));
			if (exception == null) throw new ArgumentNullException(nameof(exception));

			if (this.IsEnabled)
			{
				adapter.Insert(feature, exception.ToString());
			}
		}
	}
}