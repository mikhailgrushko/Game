using System;

namespace GuessWightGame.Core.Utils
{
	public static class RandomHelper
	{
		static Random Random = new Random();

		public static int GetRandom()
		{
			var result = Random.Next(Global.MinWeught, Global.MaxWeight + 1);
			return result;
		}
	}
}