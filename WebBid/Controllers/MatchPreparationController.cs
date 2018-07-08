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
        private ApplicationContext _context = new ApplicationContext();
        private SessionDataAcceess _session = new SessionDataAcceess();


        public ActionResult Index()
        {
            return View("MatchPreparation", _session.matchPreparationViewModel);
        }

        public ActionResult AddPlayer(Player player)
        {
            _session.Players.Add(player);

            return RedirectToAction("Index");
        }

        public ActionResult EditPlayer(Guid playerGuid)
        {
            var player = _session.Players.First(p => p.PlayerGuid == playerGuid);
         
            return RedirectToAction("Edit", "Player", player);
        }

        public ActionResult UpdatePlayer(Player player)
        {
            var sessionPlayer = _session.Players.First(p => p.PlayerGuid == player.PlayerGuid);

            sessionPlayer.Name = player.Name;
            sessionPlayer.Account = player.Account;

            return RedirectToAction("Index");
        }

        public ActionResult RemovePlayer(Guid playerGuid)
        {
            var players = _session.Players;
            players.Remove(players.First(p => p.PlayerGuid == playerGuid));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Save()
        {
            var match = _session.Match;
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