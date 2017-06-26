namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOrganizationfromEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Employees", new[] { "OrganizationId" });
            AlterColumn("dbo.Employees", "OrganizationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "OrganizationId");
            AddForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Employees", new[] { "OrganizationId" });
            AlterColumn("dbo.Employees", "OrganizationId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Employees", "OrganizationId");
            AddForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
    }
}
