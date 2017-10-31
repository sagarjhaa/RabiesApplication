namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActionsTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BiteAnimals", newName: "AnimalBites");
            DropPrimaryKey("dbo.AnimalBites");
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ActionType = c.String(nullable: false),
                        BiteId = c.String(maxLength: 128),
                        Comments = c.String(nullable: false),
                        DocumentId = c.String(),
                        Active = c.Boolean(nullable: false),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bites", t => t.BiteId)
                .Index(t => t.BiteId);
            
            AddPrimaryKey("dbo.AnimalBites", new[] { "Animal_Id", "Bite_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actions", "BiteId", "dbo.Bites");
            DropIndex("dbo.Actions", new[] { "BiteId" });
            DropPrimaryKey("dbo.AnimalBites");
            DropTable("dbo.Actions");
            AddPrimaryKey("dbo.AnimalBites", new[] { "Bite_Id", "Animal_Id" });
            RenameTable(name: "dbo.AnimalBites", newName: "BiteAnimals");
        }
    }
}
