using System;
using System.Data.SQLite;
using AppStudio.Data;

namespace DemoClient
{
	public sealed class SqlLiteDelegateDataReader : IFieldDataReader
	{
		private SQLiteDataReader Reader { get; }

		public SqlLiteDelegateDataReader(SQLiteDataReader reader)
		{
			if (reader == null) throw new ArgumentNullException(nameof(reader));

			this.Reader = reader;
		}

		public bool Read()
		{
			return this.Reader.Read();
		}

		public bool IsDbNull(int i)
		{
			return this.Reader.IsDBNull(i);
		}

		public int GetInt32(int i)
		{
			return this.Reader.GetInt32(i);
		}

		public long GetInt64(int i)
		{
			return this.Reader.GetInt64(i);
		}

		public decimal GetDecimal(int i)
		{
			return this.Reader.GetDecimal(i);
		}

		public string GetString(int i)
		{
			return this.Reader.GetString(i);
		}

		public DateTime GetDateTime(int i)
		{
			return this.Reader.GetDateTime(i);
		}

		public byte[] GetByteArray(int i)
		{
			var totalBytes = this.Reader.GetBytes(i, 0, null, 0, 0);
			var bytes = new byte[totalBytes];

			this.Reader.GetBytes(i, 0, bytes, 0, bytes.Length);

			return bytes;
		}
	}
}