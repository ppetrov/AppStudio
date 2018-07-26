using System;
using System.Collections.Generic;

namespace AppCore
{
	public sealed class ServiceLocator
	{
		private Dictionary<string, object> Services { get; } = new Dictionary<string, object>();
		private HashSet<string> Creators { get; } = new HashSet<string>();

		public void Register<T>(T service) where T : class
		{
			if (service == null) throw new ArgumentNullException(nameof(service));

			var key = typeof(T).FullName;
			this.Services.Add(key, service);
		}

		public void RegisterCreator<T>(Func<T> serviceCreator) where T : class
		{
			if (serviceCreator == null) throw new ArgumentNullException(nameof(serviceCreator));

			var key = typeof(T).FullName;

			this.Services.Add(key, serviceCreator);
			this.Creators.Add(key);
		}

		public T GetService<T>() where T : class
		{
			var key = typeof(T).FullName;

			var value = this.Services[key];
			if (this.Creators.Contains(key))
			{
				return ((Func<T>)value)();
			}
			return (T)value;
		}
	}
}