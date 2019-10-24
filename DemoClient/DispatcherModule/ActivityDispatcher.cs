using System;
using System.Collections.Generic;

namespace DemoClient.DispatcherModule
{
	public sealed class ActivityDispatcher : Dispatcher<Activity, ActivityResult>
	{
		public ActivityDispatcher(DispatcherSettings settings) : base(settings)
		{
		}

		public override IEnumerable<Activity> GetItems(IDisposable connection)
		{
			throw new NotImplementedException();
		}

		public override ActivityResult Process(Activity item)
		{
			throw new NotImplementedException();
		}

		public override void Mark(IDisposable connection, Activity item, ActivityResult result)
		{
			throw new NotImplementedException();
		}
	}
}