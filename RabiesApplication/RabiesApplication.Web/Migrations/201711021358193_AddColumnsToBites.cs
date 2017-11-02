namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToBites : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bites", "IsVacinated", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bites", "VaccineDate", c => c.DateTime());
            AddColumn("dbo.Bites", "VaccineExpirationDate", c => c.DateTime());
            AddColumn("dbo.Bites", "TagNumber", c => c.Int());
            AddColumn("dbo.Bites", "IsVacinatedPost", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bites", "IsVacinatedPrior", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bites", "IsQuarantine", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bites", "IsQuarantineCompleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bites", "QuarantineVerification", c => c.String());
            AddColumn("dbo.Bites", "VaccineVerification", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bites", "VaccineVerification");
            DropColumn("dbo.Bites", "QuarantineVerification");
            DropColumn("dbo.Bites", "IsQuarantineCompleted");
            DropColumn("dbo.Bites", "IsQuarantine");
            DropColumn("dbo.Bites", "IsVacinatedPrior");
            DropColumn("dbo.Bites", "IsVacinatedPost");
            DropColumn("dbo.Bites", "TagNumber");
            DropColumn("dbo.Bites", "VaccineExpirationDate");
            DropColumn("dbo.Bites", "VaccineDate");
            DropColumn("dbo.Bites", "IsVacinated");
        }
    }
}
