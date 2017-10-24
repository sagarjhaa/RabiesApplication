namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmail_HumanVictim : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HumanVictims", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HumanVictims", "Email");
        }
    }
}
