namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureZeroToOneBiteToAnimalOwnerLink : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AnimalOwners", "Id");
            AddForeignKey("dbo.AnimalOwners", "Id", "dbo.Bites", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnimalOwners", "Id", "dbo.Bites");
            DropIndex("dbo.AnimalOwners", new[] { "Id" });
        }
    }
}
