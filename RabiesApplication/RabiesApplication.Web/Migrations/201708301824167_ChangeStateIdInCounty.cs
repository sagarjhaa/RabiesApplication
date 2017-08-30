namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStateIdInCounty : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Counties", new[] { "State_Id" });
            DropColumn("dbo.Counties", "StateId");
            RenameColumn(table: "dbo.Counties", name: "State_Id", newName: "StateId");
            AlterColumn("dbo.Counties", "StateId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Counties", "StateId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Counties", new[] { "StateId" });
            AlterColumn("dbo.Counties", "StateId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Counties", name: "StateId", newName: "State_Id");
            AddColumn("dbo.Counties", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Counties", "State_Id");
        }
    }
}
