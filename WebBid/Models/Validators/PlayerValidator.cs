using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebBid.Controllers;
using WebBid.Models.Entities;

namespace WebBid.Models.Validators
{
    public class PlayerValidator : ValidationAttribute
    {
        private new const string ErrorMessage = "This name is already taken. Please insert other one.";

        static bool isNameTaken(Player player)
        {
            var session = new SessionDataAcceess();
            var players = session.Players;
            var isTaken = players.Any(p => p.Name == player.Name &&
                                      p.PlayerGuid != player.PlayerGuid);
            return isTaken;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var player = (Player)validationContext.ObjectInstance;
            var result = isNameTaken(player) == false;

            return result ?
                ValidationResult.Success :
                new ValidationResult(ErrorMessage);
        }
    }
}