using System;
using System.Collections.Generic;
using System.Diagnostics;
using AppCore.Data;

namespace AppCore
{
	public sealed class DataCache
	{
		private Dictionary<string, object> Data { get; } = new Dictionary<string, object>();
		private Dictionary<string, object> DataProviders { get; } = new Dictionary<string, object>();

		public void Register<T>(Func<IDbContext, DataCache, Dictionary<long, T>> dataProvider)
		{
			if (dataProvider == null) throw new ArgumentNullException(nameof(dataProvider));

			var key = typeof(T).FullName;
			this.DataProviders.Add(key, dataProvider);
		}

		public Dictionary<long, T> GetData<T>(IDbContext dbContext)
		{
			if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));

			var key = typeof(T).FullName;

			if (!this.Data.TryGetValue(key, out object values))
			{
				Debug.WriteLine(@"Get data from the database for type:" + key);
				var dataProvider = this.DataProviders[key] as Func<IDbContext, DataCache, Dictionary<long, T>>;
				values = dataProvider(dbContext, this);
				this.Data.Add(key, values);
			}

			return values as Dictionary<long, T>;
		}

		public void Clear()
		{
			this.Data.Clear();
		}

		public void Invalidate<T>()
		{
			var key = typeof(T).FullName;
			this.Data.Remove(key);
		}
	}
}