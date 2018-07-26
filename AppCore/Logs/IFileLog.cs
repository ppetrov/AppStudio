namespace AppCore.Logs
{
	public interface IFileLog
	{
		void Log(string message, LogLevel level);
	}
}