namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFirstNameHumanVictim : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HumanVictims", "FirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HumanVictims", "FirstName", c => c.String());
        }
    }
}
