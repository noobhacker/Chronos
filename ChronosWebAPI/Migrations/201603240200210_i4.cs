namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Happenings", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Happenings", "Name");
        }
    }
}
