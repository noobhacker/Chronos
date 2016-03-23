namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Confessions", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Confessions", "Message");
        }
    }
}
