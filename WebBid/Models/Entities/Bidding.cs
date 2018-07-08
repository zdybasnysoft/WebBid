namespace WebBid.Models.Entities
{
    public class Bidding
    {
        public int Id { get; set; }
        public BiddingName Name { get; set; }
        public Player actualPlayer { get; set; }
        public Player leadingPlayer { get; set; }
    }
}