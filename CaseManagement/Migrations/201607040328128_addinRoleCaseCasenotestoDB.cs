namespace CaseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinRoleCaseCasenotestoDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ParticipantsId = c.Int(nullable: false),
                        CaseNotesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CaseNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        CaseNoteBody = c.String(),
                        CaseNoteType = c.String(),
                        ParticipantId = c.Int(nullable: false),
                        Staff_Id = c.Int(),
                        Case_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Participants", t => t.Staff_Id)
                .ForeignKey("dbo.Cases", t => t.Case_Id)
                .Index(t => t.Staff_Id)
                .Index(t => t.Case_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Participants", "ContactNumer", c => c.String());
            AddColumn("dbo.Participants", "Email", c => c.String());
            AddColumn("dbo.Participants", "Gender", c => c.String());
            AddColumn("dbo.Participants", "CaseId", c => c.Int());
            AddColumn("dbo.Participants", "RolesId", c => c.Int());
            AddColumn("dbo.Participants", "CaseNote_Id", c => c.Int());
            CreateIndex("dbo.Participants", "CaseId");
            CreateIndex("dbo.Participants", "RolesId");
            CreateIndex("dbo.Participants", "CaseNote_Id");
            AddForeignKey("dbo.Participants", "CaseId", "dbo.Cases", "Id");
            AddForeignKey("dbo.Participants", "RolesId", "dbo.Roles", "Id");
            AddForeignKey("dbo.Participants", "CaseNote_Id", "dbo.CaseNotes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CaseNotes", "Case_Id", "dbo.Cases");
            DropForeignKey("dbo.CaseNotes", "Staff_Id", "dbo.Participants");
            DropForeignKey("dbo.Participants", "CaseNote_Id", "dbo.CaseNotes");
            DropForeignKey("dbo.Participants", "RolesId", "dbo.Roles");
            DropForeignKey("dbo.Participants", "CaseId", "dbo.Cases");
            DropIndex("dbo.Participants", new[] { "CaseNote_Id" });
            DropIndex("dbo.Participants", new[] { "RolesId" });
            DropIndex("dbo.Participants", new[] { "CaseId" });
            DropIndex("dbo.CaseNotes", new[] { "Case_Id" });
            DropIndex("dbo.CaseNotes", new[] { "Staff_Id" });
            DropColumn("dbo.Participants", "CaseNote_Id");
            DropColumn("dbo.Participants", "RolesId");
            DropColumn("dbo.Participants", "CaseId");
            DropColumn("dbo.Participants", "Gender");
            DropColumn("dbo.Participants", "Email");
            DropColumn("dbo.Participants", "ContactNumer");
            DropTable("dbo.Roles");
            DropTable("dbo.CaseNotes");
            DropTable("dbo.Cases");
        }
    }
}
