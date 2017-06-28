namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveToHumanVictim : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HumanVictims", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HumanVictims", "Active");
        }
    }
}
