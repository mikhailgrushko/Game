using GuessWightGame.Core.Game;
using GuessWightGame.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWightGame.Core.Players
{
	public class ThoroughCheater : ThoroughPlayer
	{
		public ThoroughCheater(string name) : base(name)
		{ }

		public override int Guess()
		{
			do
			{
				if (LastGuessed == 0)
				{
					LastGuessed = Start;
				}
				else if (LastGuessed < End)
				{
					LastGuessed++;
				}
			}
			while (GuessGame.GuessedNumbers.Distinct().Contains(LastGuessed));

			MyGuesses.Add(LastGuessed);
			return LastGuessed;
		}
	}
}
