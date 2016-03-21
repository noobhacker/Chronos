namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreandMoredatabases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarketItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostDateTime = c.DateTime(nullable: false),
                        ItemName = c.String(),
                        Price = c.Double(nullable: false),
                        ImageUrl = c.String(),
                        Seller_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Seller_Id)
                .Index(t => t.Seller_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MarketItems", "Seller_Id", "dbo.Students");
            DropIndex("dbo.MarketItems", new[] { "Seller_Id" });
            DropTable("dbo.MarketItems");
        }
    }
}
