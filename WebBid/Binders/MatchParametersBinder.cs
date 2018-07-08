using System.Collections.Generic;
using System.Web.Mvc;
using WebBid.Models.Entities;
using WebBid.Models.Factories;
using WebBid.Models.ViewModels;

namespace WebBid.Binders
{
    public class MatchParametersBinder : IModelBinder
    {
        private const string KEY = "matchParameter";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            MatchPreparationViewModel match = null;
            //var form = new FormCollection(controllerContext.HttpContext.Request.Form);
            //var players = form.Get("Players");

            //if (controllerContext.HttpContext.Session != null)


            //{
            //    match = (MatchPreparationViewModel)controllerContext.HttpContext.Session[KEY];
            //    if (match == null)
            //    {
            //        var matchEntity = EntitiesFactory.CreateMatch();
            //        match = new MatchPreparationViewModel()
            //        {
            //            Id = matchEntity.Id,
            //            Players = matchEntity.Players
            //        };
            //        controllerContext.HttpContext.Session[KEY] = match;
            //    }
            //}


            return match;
        }
    }
}