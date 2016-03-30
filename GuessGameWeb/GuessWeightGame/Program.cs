using GuessWightGame.Core.Game;
using GuessWightGame.Core.Players;
using GuessWightGame.Core.Utils;
using System;
using System.Collections.Generic;

namespace GuessWeightGame
{
	class Program
	{
		List<BasePlayer> Test1()
		{
			var players = new List<BasePlayer>();

			var random = new RandomPlayer("RandomPlayer");
			var memory = new MemoryPlayer("MemoryPlayer");
			var thoroughCheater = new ThoroughPlayer("ThoroughPlayer");
			var cheater = new CheaterPlayer("CheaterPlayer");
			var thorough = new ThoroughCheater("ThoroughCheater");

			players.Add(random);
			players.Add(memory);
			players.Add(thoroughCheater);
			players.Add(cheater);
			players.Add(thorough);

			return players;
		}

		List<BasePlayer> Test2()
		{
			var playersCount = 3;
			var players = new List<BasePlayer>();

			for (int i = 0; i < playersCount; i++)
			{
				var random1 = new MemoryPlayer("MemoryPlayer_" + i);
				players.Add(random1);
			}

			var cheater = new CheaterPlayer("CheaterPlayer");
			players.Add(cheater);

			var thoroughCheater = new ThoroughCheater("ThoroughCheater");
			players.Add(thoroughCheater);

			return players;
		}

		static void Main(string[] args)
		{
			var main = new Program();

			var players = main.Test2();
			var logger = new ConsoleLogger();
			var game = new GuessGame(players, logger);

			var result = game.Start();

			Console.WriteLine("Game is over ");
			Console.WriteLine("Attempts: " + game.Attempts);
			Console.WriteLine("RealWeight: " + result.RealWeight);
			Console.WriteLine("Winner: " + result.WinnerName);

			if (string.IsNullOrEmpty(result.WinnerName))
			{
				Console.WriteLine("Closest Name: " + result.Clossest.Name);
				Console.WriteLine("Closest Guess: " + result.Clossest.Guess);
			}

			Console.ReadKey();
		}
	}
}
