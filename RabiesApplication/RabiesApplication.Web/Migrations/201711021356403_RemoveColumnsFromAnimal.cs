namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumnsFromAnimal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Animals", "IsVacinated");
            DropColumn("dbo.Animals", "VaccineDate");
            DropColumn("dbo.Animals", "VaccineExpirationDate");
            DropColumn("dbo.Animals", "TagNumber");
            DropColumn("dbo.Animals", "IsVacinatedPost");
            DropColumn("dbo.Animals", "IsVacinatedPrior");
            DropColumn("dbo.Animals", "IsQuarantine");
            DropColumn("dbo.Animals", "IsQuarantineCompleted");
            DropColumn("dbo.Animals", "QuarantineVerification");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "QuarantineVerification", c => c.String());
            AddColumn("dbo.Animals", "IsQuarantineCompleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Animals", "IsQuarantine", c => c.Boolean(nullable: false));
            AddColumn("dbo.Animals", "IsVacinatedPrior", c => c.Boolean(nullable: false));
            AddColumn("dbo.Animals", "IsVacinatedPost", c => c.Boolean(nullable: false));
            AddColumn("dbo.Animals", "TagNumber", c => c.Int());
            AddColumn("dbo.Animals", "VaccineExpirationDate", c => c.DateTime());
            AddColumn("dbo.Animals", "VaccineDate", c => c.DateTime());
            AddColumn("dbo.Animals", "IsVacinated", c => c.Boolean(nullable: false));
        }
    }
}
