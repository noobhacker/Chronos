namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Happenings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Location = c.String(),
                        LocationX = c.Int(nullable: false),
                        LocationY = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Events", "DueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Desc", c => c.String());
            AddColumn("dbo.Events", "StudentId", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "StartDateTime");
            DropColumn("dbo.Events", "EndDateTime");
            DropColumn("dbo.Events", "Price");
            DropColumn("dbo.Events", "Location");
            DropColumn("dbo.Events", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "ImageUrl", c => c.String());
            AddColumn("dbo.Events", "Location", c => c.String());
            AddColumn("dbo.Events", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Events", "EndDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "StartDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "StudentId");
            DropColumn("dbo.Events", "Desc");
            DropColumn("dbo.Events", "DueDate");
            DropTable("dbo.Happenings");
        }
    }
}
