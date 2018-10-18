using System;
using System.Collections.Generic;

namespace AppCore.Data
{
	/// <summary>
	/// Defines an interface for executing SQL queries
	/// </summary>
	public interface IDbContext : IDisposable
	{
		int Execute(Query query);

		IEnumerable<T> Execute<T>(Query<T> query);

		void Complete();
	}
}