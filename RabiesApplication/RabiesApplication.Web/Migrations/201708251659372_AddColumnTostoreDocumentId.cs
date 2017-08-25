namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTostoreDocumentId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actions", "DocumentId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actions", "DocumentId");
        }
    }
}
