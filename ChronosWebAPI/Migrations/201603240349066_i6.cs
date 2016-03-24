namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Happenings", "Organizer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Happenings", "Organizer");
        }
    }
}
