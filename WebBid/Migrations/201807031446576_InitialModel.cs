 namespace WebBid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Biddings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        actualPlayer_Id = c.Int(),
                        leadingPlayer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.actualPlayer_Id)
                .ForeignKey("dbo.Players", t => t.leadingPlayer_Id)
                .Index(t => t.actualPlayer_Id)
                .Index(t => t.leadingPlayer_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BiddingState = c.Int(nullable: false),
                        Match_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.Match_Id)
                .Index(t => t.Match_Id);
            
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bididng_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Biddings", t => t.Bididng_Id)
                .Index(t => t.Bididng_Id);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deals", t => t.Deal_Id)
                .Index(t => t.Deal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.Matches", "Deal_Id", "dbo.Deals");
            DropForeignKey("dbo.Deals", "Bididng_Id", "dbo.Biddings");
            DropForeignKey("dbo.Biddings", "leadingPlayer_Id", "dbo.Players");
            DropForeignKey("dbo.Biddings", "actualPlayer_Id", "dbo.Players");
            DropIndex("dbo.Matches", new[] { "Deal_Id" });
            DropIndex("dbo.Deals", new[] { "Bididng_Id" });
            DropIndex("dbo.Players", new[] { "Match_Id" });
            DropIndex("dbo.Biddings", new[] { "leadingPlayer_Id" });
            DropIndex("dbo.Biddings", new[] { "actualPlayer_Id" });
            DropTable("dbo.Matches");
            DropTable("dbo.Deals");
            DropTable("dbo.Players");
            DropTable("dbo.Biddings");
        }
    }
}
