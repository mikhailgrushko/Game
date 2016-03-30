using System;

namespace GuessWightGame.Core.Utils
{
	public class ConsoleLogger : ILogger
	{
		public void LogMessage(string message)
		{
			Console.WriteLine(message);
		}
	}
}
