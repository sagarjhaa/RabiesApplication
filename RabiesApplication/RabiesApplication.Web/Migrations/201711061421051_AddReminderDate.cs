namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReminderDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investigations", "ReminderDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Investigations", "ReminderDate");
        }
    }
}
