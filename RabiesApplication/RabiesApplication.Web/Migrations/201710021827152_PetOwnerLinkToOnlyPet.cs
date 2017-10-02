namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetOwnerLinkToOnlyPet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PetOwners", "BiteId", "dbo.Bites");
            DropIndex("dbo.PetOwners", new[] { "BiteId" });
            DropColumn("dbo.PetOwners", "BiteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PetOwners", "BiteId", c => c.String(maxLength: 128));
            CreateIndex("dbo.PetOwners", "BiteId");
            AddForeignKey("dbo.PetOwners", "BiteId", "dbo.Bites", "Id");
        }
    }
}
