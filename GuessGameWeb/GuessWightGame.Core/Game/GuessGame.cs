using GuessWightGame.Core.Players;
using GuessWightGame.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessWightGame.Core.Game
{
	public class GuessGame
	{
		ILogger _logger;

		public GuessGame(List<BasePlayer> players, ILogger logger)
		{
			_isGuessed = false;
			_isGameEnded = false;
			_logger = logger;
			Players = players;
			NumberToGuess = RandomHelper.GetRandom();
			_logger.LogMessage("Number to Guess - " + NumberToGuess);
			GuessedNumbers = new List<int>();
		}

		public int NumberToGuess { get; set; }

		public List<BasePlayer> Players { get; set; }
		public volatile int Attempts;
		public BasePlayer Winner { get; set; }

		private static bool _isGuessed;
		private static bool _isGameEnded;
		private static bool Exit()
		{
			return (_isGuessed || _isGameEnded);
		}

		public static List<int> GuessedNumbers { get; set; }

		public bool IsGuessed(int number, BasePlayer player)
		{
			GuessedNumbers.Add(number);

			_isGuessed = NumberToGuess == number;
			Attempts++;

			_isGameEnded = Attempts == 100;

			if (_isGuessed)
			{
				if (!_isGameEnded)
				{
					Winner = player;
				}
			}
			else
			{
				var timeToWait = WaitTime(number);
				player.AddWaitTime(timeToWait);

				_logger.LogMessage("player " + player.Name + "  wait - " + player.WaitTime);
			}

			return _isGuessed;
		}

		public int WaitTime(int number)
		{
			return Math.Abs(NumberToGuess - number);
		}

		public GameResult Start()
		{
			while (!Exit())
			{
				foreach (var player in Players)
				{
					if (!player.IsWaiting)
					{
						var num = player.Guess();

						if (Exit())
						{
							break;
						}

						_logger.LogMessage("player " + player.Name + "  tryies - " + num);
						IsGuessed(num, player);
					}
				}
			}
			var result = GetResult();
			return result;
		}

		private GameResult GetResult()
		{
			var result = new GameResult();
			result.RealWeight = NumberToGuess;

			if (Winner != null)
			{
				result.WinnerName = Winner.Name;
			}

			var allNearestNumbers = new List<PlayerGuess>();

			foreach (var item in Players)
			{
				if (item.MyGuesses.Count == 0)
				{
					continue;
				}

				int closestGuess = item.MyGuesses.Aggregate((x, y) => Math.Abs(x - NumberToGuess) < Math.Abs(y - NumberToGuess) ? x : y);

				var playerGuess = new PlayerGuess();
				playerGuess.Guess = closestGuess;
				playerGuess.Name = item.Name;

				allNearestNumbers.Add(playerGuess);
			}

			if (allNearestNumbers.Count > 0)
			{
				var closest = allNearestNumbers.Aggregate((x, y) => Math.Abs(x.Guess - NumberToGuess) < Math.Abs(y.Guess - NumberToGuess) ? x : y);

				result.Clossest = closest;
			}

			return result;
		}
	}
}