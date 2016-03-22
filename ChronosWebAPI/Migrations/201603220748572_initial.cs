namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfessionLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfessionId = c.Int(nullable: false),
                        LikedById = c.Int(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Confessions", t => t.ConfessionId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.ConfessionId)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Confessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostDateTime = c.DateTime(nullable: false),
                        PostedById = c.Int(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        DailyConfessionChance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MarketItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SellerId = c.Int(nullable: false),
                        PostDateTime = c.DateTime(nullable: false),
                        ItemName = c.String(),
                        Price = c.Double(nullable: false),
                        ImageUrl = c.String(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.PrivateMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        SentDatetime = c.DateTime(nullable: false),
                        Message = c.String(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Student_Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Lecturer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionType = c.String(),
                        Day = c.Int(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectSessions", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Student_Subject", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Student_Subject", "StudentId", "dbo.Students");
            DropForeignKey("dbo.PrivateMessages", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.MarketItems", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.ConfessionLikes", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.ConfessionLikes", "ConfessionId", "dbo.Confessions");
            DropForeignKey("dbo.Confessions", "Student_Id", "dbo.Students");
            DropIndex("dbo.SubjectSessions", new[] { "SubjectId" });
            DropIndex("dbo.Student_Subject", new[] { "SubjectId" });
            DropIndex("dbo.Student_Subject", new[] { "StudentId" });
            DropIndex("dbo.PrivateMessages", new[] { "Student_Id" });
            DropIndex("dbo.MarketItems", new[] { "Student_Id" });
            DropIndex("dbo.Confessions", new[] { "Student_Id" });
            DropIndex("dbo.ConfessionLikes", new[] { "Student_Id" });
            DropIndex("dbo.ConfessionLikes", new[] { "ConfessionId" });
            DropTable("dbo.SubjectSessions");
            DropTable("dbo.Subjects");
            DropTable("dbo.Student_Subject");
            DropTable("dbo.PrivateMessages");
            DropTable("dbo.MarketItems");
            DropTable("dbo.Students");
            DropTable("dbo.Confessions");
            DropTable("dbo.ConfessionLikes");
        }
    }
}
