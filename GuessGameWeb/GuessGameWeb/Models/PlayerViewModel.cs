using GuessWightGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessGameWeb.Models
{
	public class PlayerViewModel
	{
		public string Name { get; set; }
		public PlayerType PlayerType { get; set; }
	}
}