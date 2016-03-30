using GuessWightGame.Core.Utils;
using System.Collections.Generic;

namespace GuessWightGame.Core.Players
{
	public class MemoryPlayer : BasePlayer
	{
		public List<int> WrongTryes { get; set; }

		public MemoryPlayer(string name) : base(name)
		{
			WrongTryes = new List<int>();
		}

		public override int Guess()
		{
			int result;
			do
			{
				result = RandomHelper.GetRandom();
			}
			while (WrongTryes.Contains(result));
			MyGuesses.Add(result);
			return result;
		}
	}
}
