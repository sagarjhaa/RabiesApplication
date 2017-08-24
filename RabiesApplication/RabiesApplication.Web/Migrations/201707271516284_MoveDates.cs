namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bites", "InvestigationCompletionDate", c => c.DateTime());
            AddColumn("dbo.Bites", "ReportClosedDate", c => c.DateTime());
            DropColumn("dbo.Investigations", "InvestigationCompletionDate");
            DropColumn("dbo.Investigations", "ReportClosedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Investigations", "ReportClosedDate", c => c.DateTime());
            AddColumn("dbo.Investigations", "InvestigationCompletionDate", c => c.DateTime());
            DropColumn("dbo.Bites", "ReportClosedDate");
            DropColumn("dbo.Bites", "InvestigationCompletionDate");
        }
    }
}
