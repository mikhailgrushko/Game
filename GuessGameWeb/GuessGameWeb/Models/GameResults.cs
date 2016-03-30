using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessGameWeb.Models
{
	public class GameResults
	{
		public GameResults()
		{
			Clossest = new PlayerGuess();
		}

		public int RealWeight { get; set; }
		public string WinnerName { get; set; }

		public PlayerGuess Clossest { get; set; }
	}

	public class PlayerGuess
	{
		public string Name { get; set; }
		public int Guess { get; set; }
	}
}