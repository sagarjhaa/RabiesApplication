namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLinkageHumanVictim : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HumanVictims", "CityId", c => c.String(maxLength: 128));
            AlterColumn("dbo.HumanVictims", "CountyId", c => c.String(maxLength: 128));
            AlterColumn("dbo.HumanVictims", "StateId", c => c.String(maxLength: 128));
            CreateIndex("dbo.HumanVictims", "CityId");
            CreateIndex("dbo.HumanVictims", "CountyId");
            CreateIndex("dbo.HumanVictims", "StateId");
            AddForeignKey("dbo.HumanVictims", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.HumanVictims", "CountyId", "dbo.Counties", "Id");
            AddForeignKey("dbo.HumanVictims", "StateId", "dbo.States", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HumanVictims", "StateId", "dbo.States");
            DropForeignKey("dbo.HumanVictims", "CountyId", "dbo.Counties");
            DropForeignKey("dbo.HumanVictims", "CityId", "dbo.Cities");
            DropIndex("dbo.HumanVictims", new[] { "StateId" });
            DropIndex("dbo.HumanVictims", new[] { "CountyId" });
            DropIndex("dbo.HumanVictims", new[] { "CityId" });
            AlterColumn("dbo.HumanVictims", "StateId", c => c.String());
            AlterColumn("dbo.HumanVictims", "CountyId", c => c.String());
            AlterColumn("dbo.HumanVictims", "CityId", c => c.String());
        }
    }
}
