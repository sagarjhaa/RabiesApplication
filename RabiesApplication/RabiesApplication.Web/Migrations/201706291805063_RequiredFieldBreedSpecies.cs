namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFieldBreedSpecies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropIndex("dbo.Animals", new[] { "SpeciesId" });
            DropIndex("dbo.Animals", new[] { "BreedId" });
            AlterColumn("dbo.Animals", "SpeciesId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Animals", "BreedId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Animals", "SpeciesId");
            CreateIndex("dbo.Animals", "BreedId");
            AddForeignKey("dbo.Animals", "BreedId", "dbo.Breeds", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Animals", "SpeciesId", "dbo.Species", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Animals", "BreedId", "dbo.Breeds");
            DropIndex("dbo.Animals", new[] { "BreedId" });
            DropIndex("dbo.Animals", new[] { "SpeciesId" });
            AlterColumn("dbo.Animals", "BreedId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Animals", "SpeciesId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Animals", "BreedId");
            CreateIndex("dbo.Animals", "SpeciesId");
            AddForeignKey("dbo.Animals", "SpeciesId", "dbo.Species", "Id");
            AddForeignKey("dbo.Animals", "BreedId", "dbo.Breeds", "Id");
        }
    }
}
