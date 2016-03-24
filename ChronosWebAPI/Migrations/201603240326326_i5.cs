namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Happenings", "FbUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Happenings", "FbUrl");
        }
    }
}
