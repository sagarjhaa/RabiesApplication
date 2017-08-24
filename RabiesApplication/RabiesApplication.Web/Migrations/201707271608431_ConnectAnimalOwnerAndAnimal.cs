namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectAnimalOwnerAndAnimal : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PetOwners", "Id");
            AddForeignKey("dbo.PetOwners", "Id", "dbo.Animals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetOwners", "Id", "dbo.Animals");
            DropIndex("dbo.PetOwners", new[] { "Id" });
        }
    }
}
