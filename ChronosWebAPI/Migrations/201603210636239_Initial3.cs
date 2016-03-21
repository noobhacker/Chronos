namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subject_SubjectSession",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject_Id = c.Int(),
                        SubjectSession_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.SubjectSessions", t => t.SubjectSession_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.SubjectSession_Id);
            
            CreateTable(
                "dbo.SubjectSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        SessionType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subject_SubjectSession", "SubjectSession_Id", "dbo.SubjectSessions");
            DropForeignKey("dbo.Subject_SubjectSession", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Subject_SubjectSession", new[] { "SubjectSession_Id" });
            DropIndex("dbo.Subject_SubjectSession", new[] { "Subject_Id" });
            DropTable("dbo.SubjectSessions");
            DropTable("dbo.Subject_SubjectSession");
        }
    }
}
