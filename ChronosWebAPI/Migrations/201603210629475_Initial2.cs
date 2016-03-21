namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student_Subject", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Student_Subject", "Student_Id", "dbo.Students");
            DropIndex("dbo.Student_Subject", new[] { "Subject_Id" });
            DropIndex("dbo.Student_Subject", new[] { "Student_Id" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Student_Subject");
        }
    }
}
