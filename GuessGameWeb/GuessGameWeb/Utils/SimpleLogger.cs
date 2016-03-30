using GuessWightGame.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessGameWeb.Utils
{
	public class SimpleLogger : ILogger
	{
		public SimpleLogger()
		{
			Messages = new List<string>();
		}

		public List<string> Messages;
		public void LogMessage(string message)
		{
			Messages.Add(message);
		}
	}
}