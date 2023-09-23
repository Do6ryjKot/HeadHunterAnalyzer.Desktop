namespace Contracts.Logger {
	
	/// <summary>
	/// Сервис логгирования
	/// </summary>
	public interface ILoggerManager {

		public void LogInformation(string message);
		public void LogWarning(string message);
		public void LogDebug(string message);
		public void LogError(string message);
	}
}
