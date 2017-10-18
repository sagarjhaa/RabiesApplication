namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBiteIdFromAnimal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "BiteId", "dbo.Bites");
            DropIndex("dbo.Animals", new[] { "BiteId" });
            DropColumn("dbo.Animals", "BiteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "BiteId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Animals", "BiteId");
            AddForeignKey("dbo.Animals", "BiteId", "dbo.Bites", "Id");
        }
    }
}
