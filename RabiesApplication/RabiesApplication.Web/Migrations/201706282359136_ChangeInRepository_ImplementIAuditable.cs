namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInRepository_ImplementIAuditable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BiteStatus", "RecordCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.BiteStatus", "RecordEdited", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.BiteStatus", "EmployeeCreatedId", c => c.String());
            AddColumn("dbo.BiteStatus", "EmployeeEditedId", c => c.String());
            AddColumn("dbo.Cities", "RecordCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Cities", "RecordEdited", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Cities", "EmployeeCreatedId", c => c.String());
            AddColumn("dbo.Cities", "EmployeeEditedId", c => c.String());
            AddColumn("dbo.States", "RecordCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.States", "RecordEdited", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.States", "EmployeeCreatedId", c => c.String());
            AddColumn("dbo.States", "EmployeeEditedId", c => c.String());
            AddColumn("dbo.Counties", "RecordCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Counties", "RecordEdited", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Counties", "EmployeeCreatedId", c => c.String());
            AddColumn("dbo.Counties", "EmployeeEditedId", c => c.String());
            DropColumn("dbo.HumanVictims", "Active");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HumanVictims", "Active", c => c.Boolean(nullable: false));
            DropColumn("dbo.Counties", "EmployeeEditedId");
            DropColumn("dbo.Counties", "EmployeeCreatedId");
            DropColumn("dbo.Counties", "RecordEdited");
            DropColumn("dbo.Counties", "RecordCreated");
            DropColumn("dbo.States", "EmployeeEditedId");
            DropColumn("dbo.States", "EmployeeCreatedId");
            DropColumn("dbo.States", "RecordEdited");
            DropColumn("dbo.States", "RecordCreated");
            DropColumn("dbo.Cities", "EmployeeEditedId");
            DropColumn("dbo.Cities", "EmployeeCreatedId");
            DropColumn("dbo.Cities", "RecordEdited");
            DropColumn("dbo.Cities", "RecordCreated");
            DropColumn("dbo.BiteStatus", "EmployeeEditedId");
            DropColumn("dbo.BiteStatus", "EmployeeCreatedId");
            DropColumn("dbo.BiteStatus", "RecordEdited");
            DropColumn("dbo.BiteStatus", "RecordCreated");
        }
    }
}
