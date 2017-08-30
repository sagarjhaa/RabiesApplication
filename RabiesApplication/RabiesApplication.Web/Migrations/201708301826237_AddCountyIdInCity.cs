namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountyIdInCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "CountyId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cities", "CountyId");
            AddForeignKey("dbo.Cities", "CountyId", "dbo.Counties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "CountyId", "dbo.Counties");
            DropIndex("dbo.Cities", new[] { "CountyId" });
            DropColumn("dbo.Cities", "CountyId");
        }
    }
}
