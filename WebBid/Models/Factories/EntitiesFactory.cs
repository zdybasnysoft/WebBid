using System;
using System.Collections.Generic;
using WebBid.Models.Entities;

namespace WebBid.Models.Factories
{
    public class EntitiesFactory
    {
        public static Match CreateMatch()
        {
            return new Match()
            {
                Players = new List<Player>(),
                Deal = new Deal()
                {
                    Bididng = new Bidding()
                    {
                        Name = BiddingName.PreFlop
                    }
                }
            };
        }

        public static Player CreatePlayer()
        {
            var newGuid = Guid.NewGuid();
            return new Player()
            {
                PlayerGuid = newGuid,
                Name = "Player_" + newGuid.ToString().Substring(0, 3)
            };
        }
    }
}