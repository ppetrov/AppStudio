using System;

namespace DemoClient.DispatcherModule
{
	public sealed class DispatcherSettings
	{
		public int Workers { get; } = 8;
		public TimeSpan QueryInterval { get; } = TimeSpan.FromSeconds(30);
		public Action<string, Exception> Log { get; }
	}
}