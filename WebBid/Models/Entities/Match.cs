using System.Collections.Generic;

namespace WebBid.Models.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public ICollection<Player> Players { get; set; }
        public Deal Deal { get; set; }
    }
}