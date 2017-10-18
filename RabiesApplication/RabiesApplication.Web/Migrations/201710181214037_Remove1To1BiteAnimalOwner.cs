namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove1To1BiteAnimalOwner : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AnimalBites", newName: "BiteAnimals");
            DropForeignKey("dbo.AnimalOwners", "Id", "dbo.Bites");
            DropIndex("dbo.AnimalOwners", new[] { "Id" });
            DropPrimaryKey("dbo.BiteAnimals");
            AddPrimaryKey("dbo.BiteAnimals", new[] { "Bite_Id", "Animal_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BiteAnimals");
            AddPrimaryKey("dbo.BiteAnimals", new[] { "Animal_Id", "Bite_Id" });
            CreateIndex("dbo.AnimalOwners", "Id");
            AddForeignKey("dbo.AnimalOwners", "Id", "dbo.Bites", "Id");
            RenameTable(name: "dbo.BiteAnimals", newName: "AnimalBites");
        }
    }
}
