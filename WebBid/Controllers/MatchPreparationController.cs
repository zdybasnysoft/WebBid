using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebBid.Models;
using WebBid.Models.Entities;
using WebBid.Models.Factories;
using WebBid.Models.ViewModels;

namespace WebBid.Controllers
{
    public class MatchPreparationController : Controller
    {
        private const string KEY = "sessionKey";
        private ApplicationContext _context = new ApplicationContext();

        private MatchPreparationViewModel SessionModel
        {
            get
            {
                if (!(Session[KEY] is MatchPreparationViewModel model))
                {
                    model = new MatchPreparationViewModel()
                    {
                        Match = EntitiesFactory.CreateMatch()
                    };
                    Session[KEY] = model;
                }
                return model;
            }
        }

        private Match SessionMatch => SessionModel.Match;

        private ICollection<Player> SessionPlayers => SessionMatch.Players;

        public ActionResult Index()
        {
            return View("MatchPreparation", SessionModel);
        }

        public ActionResult AddPlayer(Player player)
        {
            SessionPlayers.Add(player);

            return RedirectToAction("Index");
        }

        public ActionResult EditPlayer(Guid playerGuid)
        {
            var player = SessionPlayers.First(p => p.PlayerGuid == playerGuid);
         
            return RedirectToAction("Edit", "Player", player);
        }

        public ActionResult UpdatePlayer(Player player)
        {
            var sessionPlayer = SessionPlayers.First(p => p.PlayerGuid == player.PlayerGuid);

            sessionPlayer.Name = player.Name;
            sessionPlayer.Account = player.Account;

            return RedirectToAction("Index");
        }

        public ActionResult RemovePlayer(Guid playerGuid)
        {
            var players = SessionPlayers;
            players.Remove(players.First(p => p.PlayerGuid == playerGuid));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Save()
        {
            var match = SessionMatch;
            if (match.Id == 0)
            {
                _context.Matches.Add(match);
            }
            else
            {
                var dbMatch = _context.Matches.First(m => m.Id == match.Id);
                dbMatch = match;
            }

            return RedirectToAction("Index", match);
        }
    }
}