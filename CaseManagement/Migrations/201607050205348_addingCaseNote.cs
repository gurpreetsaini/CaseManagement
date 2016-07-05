namespace CaseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingCaseNote : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CaseNotes", "DateUpdated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CaseNotes", "DateUpdated", c => c.DateTime(nullable: false));
        }
    }
}
