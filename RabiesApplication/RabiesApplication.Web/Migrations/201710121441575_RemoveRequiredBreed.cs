namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredBreed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.Pets", "BreedId", "dbo.Breeds");
            DropIndex("dbo.Animals", new[] { "BreedId" });
            DropIndex("dbo.Pets", new[] { "BreedId" });
            AlterColumn("dbo.Animals", "BreedId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Pets", "BreedId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Animals", "BreedId");
            CreateIndex("dbo.Pets", "BreedId");
            AddForeignKey("dbo.Animals", "BreedId", "dbo.Breeds", "Id");
            AddForeignKey("dbo.Pets", "BreedId", "dbo.Breeds", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.Animals", "BreedId", "dbo.Breeds");
            DropIndex("dbo.Pets", new[] { "BreedId" });
            DropIndex("dbo.Animals", new[] { "BreedId" });
            AlterColumn("dbo.Pets", "BreedId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Animals", "BreedId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Pets", "BreedId");
            CreateIndex("dbo.Animals", "BreedId");
            AddForeignKey("dbo.Pets", "BreedId", "dbo.Breeds", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Animals", "BreedId", "dbo.Breeds", "Id", cascadeDelete: true);
        }
    }
}
