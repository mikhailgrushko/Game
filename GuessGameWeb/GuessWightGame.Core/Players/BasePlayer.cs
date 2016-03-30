using System;
using System.Collections.Generic;

namespace GuessWightGame.Core.Players
{
	public abstract class BasePlayer
	{
		public List<int> MyGuesses;
		public BasePlayer(string name)
		{
			Name = name;
			MyGuesses = new List<int>();
		}

		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}

		PlayerType _playerType;
		public PlayerType PlayerType
		{
			get
			{
				return _playerType;
			}

			set
			{
				_playerType = value;
			}
		}

		public DateTime? TryiedGuess { get; set; }
		public int WaitTime { get; set; }

		public void AddWaitTime(int timeToWait)
		{
			TryiedGuess = DateTime.Now;
			WaitTime = timeToWait;
		}

		public bool IsWaiting
		{
			get
			{
				if (TryiedGuess.HasValue)
				{
					var isReady = DateTime.Now < TryiedGuess.Value.AddMilliseconds(WaitTime);
					if (isReady)
					{
						TryiedGuess = null;
						WaitTime = 0;
					}
					return isReady;
				}

				return false;
			}
		}

		public abstract int Guess();
	}
}