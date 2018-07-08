namespace WebBid.Models
{
    using System.Data.Entity;
    using WebBid.Models.Entities;

    public partial class ApplicationContext : DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Bidding> Biddings { get; set; }

        public ApplicationContext()
            : base("name=ApplicationContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
