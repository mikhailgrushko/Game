using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWightGame.Core
{
    public interface IPlayer
    {
		string Name { get; set; }
		PlayerType PlayerType { get; set; }
		int Guess();
    }
}