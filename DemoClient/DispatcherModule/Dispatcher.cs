using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DemoClient.DispatcherModule
{
	public abstract class Dispatcher<TItem, TResult>
		where TItem : IDispatcherItem
		where TResult : class
	{
		private bool IsRunning { get; set; }
		private ConcurrentQueue<TItem> SharedItems { get; } = new ConcurrentQueue<TItem>();
		private ManualResetEventSlim DoneEvent { get; } = new ManualResetEventSlim(false);

		public DispatcherSettings Settings { get; }

		protected Dispatcher(DispatcherSettings settings)
		{
			if (settings == null) throw new ArgumentNullException(nameof(settings));

			this.Settings = settings;
		}

		public void Start()
		{
			this.IsRunning = true;
			this.SharedItems.Clear();

			Task.Run(() =>
			{
				try
				{
					while (this.IsRunning)
					{
						var s = Stopwatch.StartNew();
						try
						{
							using (var connection = default(IDisposable))
							{
								try
								{
									foreach (var item in this.GetItems(connection))
									{
										this.SharedItems.Enqueue(item);
									}
								}
								catch (Exception ex)
								{
									this.Log(nameof(this.GetItems), ex);
								}
								if (this.SharedItems.Count > 0)
								{
									Task.WaitAll(this.StartWorkers(connection,
										Math.Min(this.SharedItems.Count, this.Settings.Workers)));
								}
							}
						}
						catch (Exception ex)
						{
							this.Log(@"Dispatcher loop", ex);
						}

						var sleepTime = this.Settings.QueryInterval - s.Elapsed;
						while (sleepTime > TimeSpan.Zero && this.IsRunning)
						{
							var second = TimeSpan.FromSeconds(1);
							Thread.Sleep(second);
							sleepTime -= second;
						}
					}
				}
				catch (Exception ex)
				{
					this.Log(@"Dispatcher task", ex);
				}
				finally
				{
					this.DoneEvent.Set();
				}
			});
		}

		public void Stop()
		{
			this.IsRunning = false;
			this.SharedItems.Clear();
			this.DoneEvent.Wait();
		}

		private Task[] StartWorkers(IDisposable connection, int workersCount)
		{
			var workers = new Task[workersCount];

			for (var i = 0; i < workers.Length; i++)
			{
				workers[i] = Task.Run(() =>
				{
					try
					{
						while (this.SharedItems.TryDequeue(out var item))
						{
							var result = default(TResult);
							try
							{
								result = this.Process(item);
							}
							catch (Exception ex)
							{
								result = null;
								this.Log(item.Id + Environment.NewLine + nameof(this.Process), ex);
							}
							try
							{
								lock (connection)
								{
									this.Mark(connection, item, result);
								}
							}
							catch (Exception ex)
							{
								this.Log(item.Id + Environment.NewLine + nameof(this.Mark), ex);
							}
						}
					}
					catch (Exception ex)
					{
						this.Log(@"Worker", ex);
					}
				});
			}

			return workers;
		}

		public abstract IEnumerable<TItem> GetItems(IDisposable connection);

		public abstract TResult Process(TItem item);

		public abstract void Mark(IDisposable connection, TItem item, TResult result);

		private void Log(string context, Exception exception)
		{
			this.Settings.Log(context, exception);
		}
	}
}