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
                        PostDateTime = c.DateTime(nullable: false),
                        ItemName = c.String(),
                        Price = c.Double(nullable: false),
                        ImageUrl = c.String(),
                        Seller_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Seller_Id)
                .Index(t => t.Seller_Id);
            
            CreateTable(
                "dbo.PrivateMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SentDatetime = c.DateTime(nullable: false),
                        Message = c.String(),
                        Receiver_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Receiver_Id)
                .ForeignKey("dbo.Students", t => t.Sender_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.Student_Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Student_Id = c.Int(),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Subject_Id);
            
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
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.Subject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectSessions", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Student_Subject", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Student_Subject", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.PrivateMessages", "Sender_Id", "dbo.Students");
            DropForeignKey("dbo.PrivateMessages", "Receiver_Id", "dbo.Students");
            DropForeignKey("dbo.MarketItems", "Seller_Id", "dbo.Students");
            DropForeignKey("dbo.ConfessionLikes", "LikedBy_Id", "dbo.Students");
            DropForeignKey("dbo.ConfessionLikes", "Confession_Id", "dbo.Confessions");
            DropForeignKey("dbo.Confessions", "PostedBy_Id", "dbo.Students");
            DropIndex("dbo.SubjectSessions", new[] { "Subject_Id" });
            DropIndex("dbo.Student_Subject", new[] { "Subject_Id" });
            DropIndex("dbo.Student_Subject", new[] { "Student_Id" });
            DropIndex("dbo.PrivateMessages", new[] { "Sender_Id" });
            DropIndex("dbo.PrivateMessages", new[] { "Receiver_Id" });
            DropIndex("dbo.MarketItems", new[] { "Seller_Id" });
            DropIndex("dbo.Confessions", new[] { "PostedBy_Id" });
            DropIndex("dbo.ConfessionLikes", new[] { "LikedBy_Id" });
            DropIndex("dbo.ConfessionLikes", new[] { "Confession_Id" });
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
