using System;
using AppCore.Features;
using AppCore.Logs;
using AppCore.Sort;

namespace AppCore
{
	public sealed class MainContext
	{
		private ServiceLocator ServiceLocator { get; } = new ServiceLocator();
		private FeatureManager FeatureManager { get; } = new FeatureManager();

		public T GetService<T>() where T : class
		{
			return this.ServiceLocator.GetService<T>();
		}

		public void RegisterService<T>(T service) where T : class
		{
			if (service == null) throw new ArgumentNullException(nameof(service));

			this.ServiceLocator.Register(service);
		}

		public void RegisterServiceCreator<T>(Func<T> serviceCreator) where T : class
		{
			if (serviceCreator == null) throw new ArgumentNullException(nameof(serviceCreator));

			this.ServiceLocator.RegisterCreator(serviceCreator);
		}

		public void Save(Feature feature)
		{
			if (feature == null) throw new ArgumentNullException(nameof(feature));

			this.FeatureManager.Save(this.GetService<IFeatureDataAdapter>(), feature);
		}

		public void Save(Feature feature, Exception exception)
		{
			if (feature == null) throw new ArgumentNullException(nameof(feature));
			if (exception == null) throw new ArgumentNullException(nameof(exception));

			this.FeatureManager.Save(this.GetService<IFeatureDataAdapter>(), feature, exception);
		}

		public void Log(Exception exception)
		{
			if (exception == null) throw new ArgumentNullException(nameof(exception));

			this.GetService<ILogger>().Log(exception.ToString(), LogLevel.Error);
		}

		public void BeginInvokeOnMainThread(Action action)
		{
			if (action == null) throw new ArgumentNullException(nameof(action));

			try
			{
				action();
			}
			catch (Exception ex)
			{
				this.Log(ex);
			}
		}

		public void SelectSortOption(SortOption[] sortOptions, Action<SortOption> applySort)
		{
			if (sortOptions == null) throw new ArgumentNullException(nameof(sortOptions));

			// TODO : !!! Display Sort Options selector
			Action _ = () =>
			{
				// TODO : !!!
				applySort(default(SortOption));
			};
			_();
		}
	}
}