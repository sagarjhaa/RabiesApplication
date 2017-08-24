namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeActionEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actions", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actions", "Active");
        }
    }
}
