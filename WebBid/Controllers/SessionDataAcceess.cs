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
    public class SessionDataAcceess : Controller
    {
        private const string KEY = "sessionKey";

        public MatchPreparationViewModel matchPreparationViewModel
        {
            get
            {
                if (!(System.Web.HttpContext.Current.Session[KEY] is MatchPreparationViewModel model))
                {
                    model = new MatchPreparationViewModel()
                    {
                        Match = EntitiesFactory.CreateMatch()
                    };
                    System.Web.HttpContext.Current.Session[KEY] = model;
                }
                return model;
            }
        }

        public Match Match => matchPreparationViewModel.Match;

        public ICollection<Player> Players => Match.Players;
    }
}