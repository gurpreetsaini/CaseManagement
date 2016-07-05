namespace CaseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFamily : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Participants", "Family_Id", c => c.Int());
            CreateIndex("dbo.Participants", "Family_Id");
            AddForeignKey("dbo.Participants", "Family_Id", "dbo.Families", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "Family_Id", "dbo.Families");
            DropIndex("dbo.Participants", new[] { "Family_Id" });
            DropColumn("dbo.Participants", "Family_Id");
            DropTable("dbo.Families");
        }
    }
}
