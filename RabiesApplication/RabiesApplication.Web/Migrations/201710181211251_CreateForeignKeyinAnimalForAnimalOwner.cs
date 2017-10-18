namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateForeignKeyinAnimalForAnimalOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "AnimalOwnerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Animals", "AnimalOwnerId");
            AddForeignKey("dbo.Animals", "AnimalOwnerId", "dbo.AnimalOwners", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "AnimalOwnerId", "dbo.AnimalOwners");
            DropIndex("dbo.Animals", new[] { "AnimalOwnerId" });
            DropColumn("dbo.Animals", "AnimalOwnerId");
        }
    }
}
