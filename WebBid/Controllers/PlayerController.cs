using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBid.Models.Entities;
using WebBid.Models.Factories;
using WebBid.Models.ViewModels;

namespace WebBid.Controllers
{
    public class PlayerController : Controller
    {
        private SessionDataAcceess _session = new SessionDataAcceess();

        [HttpGet]
        public ActionResult Edit(Player player)
        {
            var model = new PlayerEditionViewModel() { Player = player };
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveNewPlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                player.PlayerGuid = Guid.NewGuid();
                return RedirectToAction("AddPlayer", "MatchPreparation", player);
            }

            var model = new PlayerEditionViewModel() { Player = player };
            return View("New", model);
        }

        [HttpPost]
        public ActionResult SaveEditedPlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("UpdatePlayer", "MatchPreparation", player);
            }

            var model = new PlayerEditionViewModel() { Player = player };
            return View("Edit", model);
        }
    }
}