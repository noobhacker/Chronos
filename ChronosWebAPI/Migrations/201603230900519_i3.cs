namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarketItems", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MarketItems", "Description");
        }
    }
}
