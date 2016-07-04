namespace CaseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtitionalClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Participants", "ContactNumer");
            DropColumn("dbo.Participants", "LegalStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participants", "LegalStatus", c => c.String());
            AddColumn("dbo.Participants", "ContactNumer", c => c.String());
        }
    }
}
