namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreDatabase2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrivateMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        SentDatetime = c.DateTime(nullable: false),
                        Receiver_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Receiver_Id)
                .ForeignKey("dbo.Students", t => t.Sender_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrivateMessages", "Sender_Id", "dbo.Students");
            DropForeignKey("dbo.PrivateMessages", "Receiver_Id", "dbo.Students");
            DropIndex("dbo.PrivateMessages", new[] { "Sender_Id" });
            DropIndex("dbo.PrivateMessages", new[] { "Receiver_Id" });
            DropTable("dbo.PrivateMessages");
        }
    }
}
