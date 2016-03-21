namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefinedDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subject_SubjectSession", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Subject_SubjectSession", "SubjectSession_Id", "dbo.SubjectSessions");
            DropIndex("dbo.Subject_SubjectSession", new[] { "Subject_Id" });
            DropIndex("dbo.Subject_SubjectSession", new[] { "SubjectSession_Id" });
            CreateTable(
                "dbo.ConfessionLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Confession_Id = c.Int(),
                        LikedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Confessions", t => t.Confession_Id)
                .ForeignKey("dbo.Students", t => t.LikedBy_Id)
                .Index(t => t.Confession_Id)
                .Index(t => t.LikedBy_Id);
            
            CreateTable(
                "dbo.Confessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostDateTime = c.DateTime(nullable: false),
                        PostedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.PostedBy_Id)
                .Index(t => t.PostedBy_Id);
            
            AddColumn("dbo.SubjectSessions", "Subject_Id", c => c.Int());
            CreateIndex("dbo.SubjectSessions", "Subject_Id");
            AddForeignKey("dbo.SubjectSessions", "Subject_Id", "dbo.Subjects", "Id");
            DropTable("dbo.Subject_SubjectSession");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subject_SubjectSession",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject_Id = c.Int(),
                        SubjectSession_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.SubjectSessions", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.ConfessionLikes", "LikedBy_Id", "dbo.Students");
            DropForeignKey("dbo.ConfessionLikes", "Confession_Id", "dbo.Confessions");
            DropForeignKey("dbo.Confessions", "PostedBy_Id", "dbo.Students");
            DropIndex("dbo.SubjectSessions", new[] { "Subject_Id" });
            DropIndex("dbo.Confessions", new[] { "PostedBy_Id" });
            DropIndex("dbo.ConfessionLikes", new[] { "LikedBy_Id" });
            DropIndex("dbo.ConfessionLikes", new[] { "Confession_Id" });
            DropColumn("dbo.SubjectSessions", "Subject_Id");
            DropTable("dbo.Confessions");
            DropTable("dbo.ConfessionLikes");
            CreateIndex("dbo.Subject_SubjectSession", "SubjectSession_Id");
            CreateIndex("dbo.Subject_SubjectSession", "Subject_Id");
            AddForeignKey("dbo.Subject_SubjectSession", "SubjectSession_Id", "dbo.SubjectSessions", "Id");
            AddForeignKey("dbo.Subject_SubjectSession", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}
