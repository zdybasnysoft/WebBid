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
    }
}