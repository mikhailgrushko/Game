using GuessWightGame.Core.Utils;

namespace GuessWightGame.Core.Players
{
	public class RandomPlayer : BasePlayer
	{
		public RandomPlayer(string name) : base(name)
		{}

		public override int Guess()
		{
			int result = RandomHelper.GetRandom(); //creates a number between 40 and 140
			MyGuesses.Add(result);
			return result;
		}
	}
}
