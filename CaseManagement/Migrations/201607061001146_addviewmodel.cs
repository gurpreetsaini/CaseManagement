namespace CaseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addviewmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Participants", "CaseId", "dbo.Cases");
            AddColumn("dbo.Cases", "DateOpened", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cases", "DateUpdated", c => c.DateTime());
            AddColumn("dbo.Cases", "DateClosed", c => c.DateTime());
            AddColumn("dbo.Cases", "KeyWorker_Id", c => c.Int());
            AddColumn("dbo.Participants", "Case_Id", c => c.Int());
            CreateIndex("dbo.Cases", "KeyWorker_Id");
            CreateIndex("dbo.Participants", "Case_Id");
            AddForeignKey("dbo.Cases", "KeyWorker_Id", "dbo.Participants", "Id");
            AddForeignKey("dbo.Participants", "Case_Id", "dbo.Cases", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "Case_Id", "dbo.Cases");
            DropForeignKey("dbo.Cases", "KeyWorker_Id", "dbo.Participants");
            DropIndex("dbo.Participants", new[] { "Case_Id" });
            DropIndex("dbo.Cases", new[] { "KeyWorker_Id" });
            DropColumn("dbo.Participants", "Case_Id");
            DropColumn("dbo.Cases", "KeyWorker_Id");
            DropColumn("dbo.Cases", "DateClosed");
            DropColumn("dbo.Cases", "DateUpdated");
            DropColumn("dbo.Cases", "DateOpened");
            AddForeignKey("dbo.Participants", "CaseId", "dbo.Cases", "Id");
        }
    }
}
