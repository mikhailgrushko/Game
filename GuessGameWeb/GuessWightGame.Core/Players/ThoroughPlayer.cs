using GuessWightGame.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWightGame.Core.Players
{
	public class ThoroughPlayer : BasePlayer
	{
		public int Start { get; set; }
		public int End { get; set; }
		public int LastGuessed { get; set; }

		public ThoroughPlayer(string name) : base(name)
		{
			Start = Global.MinWeught;
			End = Global.MaxWeight;
		}

		public override int Guess()
		{
			if (LastGuessed == 0)
			{
				LastGuessed = Start;
			}
			else if (LastGuessed < End)
			{
				LastGuessed++;
			}

			MyGuesses.Add(LastGuessed);

			return LastGuessed;
		}
	}
}
