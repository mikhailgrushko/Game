using GuessWightGame.Core.Game;
using GuessWightGame.Core.Utils;

namespace GuessWightGame.Core.Players
{
	public class CheaterPlayer : BasePlayer
	{
		public CheaterPlayer(string name) : base(name)
		{}

		public override int Guess()
		{
			int result;
			do
			{
				result = RandomHelper.GetRandom();
			}
			while (GuessGame.GuessedNumbers.Contains(result));
			MyGuesses.Add(result);
			return result;
		}
	}
}
