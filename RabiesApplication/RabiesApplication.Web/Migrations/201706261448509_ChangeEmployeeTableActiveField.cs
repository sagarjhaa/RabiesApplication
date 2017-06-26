namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmployeeTableActiveField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Active", c => c.Byte(nullable: false));
        }
    }
}
