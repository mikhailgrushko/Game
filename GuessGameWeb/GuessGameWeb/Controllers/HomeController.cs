using GuessGameWeb.Models;
using GuessGameWeb.Utils;
using GuessWightGame.Core.Game;
using GuessWightGame.Core.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuessGameWeb.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult StartGame(List<PlayerViewModel> players)
		{
			var logger = new SimpleLogger();
			if (players != null)
			{
				var pl = players.Select(x => GetCorrectPlayer(x)).ToList();
				var game = new GuessGame(pl, logger);

				var result = game.Start();

				return Json(result, JsonRequestBehavior.AllowGet);
			}

			return new EmptyResult();
		}

		private BasePlayer GetCorrectPlayer(PlayerViewModel playerModel)
		{
			BasePlayer basePlayer = new RandomPlayer(playerModel.Name);
			switch (playerModel.PlayerType)
			{
				case GuessWightGame.Core.PlayerType.Random:
					basePlayer = new RandomPlayer(playerModel.Name);
					break;
				case GuessWightGame.Core.PlayerType.Memory :
					basePlayer = new MemoryPlayer(playerModel.Name);
					break;
				case GuessWightGame.Core.PlayerType.Thorough:
					basePlayer = new ThoroughPlayer(playerModel.Name);
					break;
				case GuessWightGame.Core.PlayerType.Cheater:
					basePlayer = new CheaterPlayer(playerModel.Name);
					break;
				case GuessWightGame.Core.PlayerType.ThoroughCheater:
					basePlayer = new ThoroughCheater(playerModel.Name);
					break;
			}

			return basePlayer;
		}
	}
}