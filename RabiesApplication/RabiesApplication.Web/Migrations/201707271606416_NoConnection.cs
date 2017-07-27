namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoConnection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PetOwners", "AnimalId", "dbo.Animals");
            DropIndex("dbo.PetOwners", new[] { "AnimalId" });
            DropColumn("dbo.PetOwners", "AnimalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PetOwners", "AnimalId", c => c.String(maxLength: 128));
            CreateIndex("dbo.PetOwners", "AnimalId");
            AddForeignKey("dbo.PetOwners", "AnimalId", "dbo.Animals", "Id");
        }
    }
}
