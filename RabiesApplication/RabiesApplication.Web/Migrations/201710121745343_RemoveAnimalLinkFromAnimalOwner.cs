namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAnimalLinkFromAnimalOwner : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnimalOwners", "Animal_Id", "dbo.Animals");
            DropIndex("dbo.AnimalOwners", new[] { "Animal_Id" });
            DropColumn("dbo.AnimalOwners", "Animal_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnimalOwners", "Animal_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AnimalOwners", "Animal_Id");
            AddForeignKey("dbo.AnimalOwners", "Animal_Id", "dbo.Animals", "Id");
        }
    }
}
