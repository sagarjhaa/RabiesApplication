namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnimalTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalOwners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsShelter = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Dateofbirth = c.DateTimeOffset(precision: 7),
                        Age = c.Int(),
                        Addressline1 = c.String(),
                        Addressline2 = c.String(),
                        CityId = c.String(maxLength: 128),
                        CountyId = c.String(),
                        StateId = c.String(maxLength: 128),
                        Zipcode = c.Int(nullable: false),
                        Contactnumber1 = c.String(),
                        Contactnumber2 = c.String(),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                        Animal_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.Animal_Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.StateId)
                .Index(t => t.Animal_Id);
            
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BiteId = c.String(maxLength: 128),
                        VetId = c.String(maxLength: 128),
                        SpeciesId = c.String(nullable: false, maxLength: 128),
                        BreedId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Sex = c.Boolean(nullable: false),
                        IsVacinated = c.Boolean(nullable: false),
                        VaccineDate = c.DateTime(),
                        VaccineExpirationDate = c.DateTime(),
                        TagNumber = c.Int(),
                        IsVacinatedPost = c.Boolean(nullable: false),
                        IsVacinatedPrior = c.Boolean(nullable: false),
                        IsQuarantine = c.Boolean(nullable: false),
                        IsQuarantineCompleted = c.Boolean(nullable: false),
                        QuarantineVerification = c.String(),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bites", t => t.BiteId)
                .ForeignKey("dbo.Breeds", t => t.BreedId, cascadeDelete: true)
                .ForeignKey("dbo.Species", t => t.SpeciesId, cascadeDelete: true)
                .ForeignKey("dbo.Vets", t => t.VetId)
                .Index(t => t.BiteId)
                .Index(t => t.VetId)
                .Index(t => t.SpeciesId)
                .Index(t => t.BreedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnimalOwners", "StateId", "dbo.States");
            DropForeignKey("dbo.AnimalOwners", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AnimalOwners", "Animal_Id", "dbo.Animals");
            DropForeignKey("dbo.Animals", "VetId", "dbo.Vets");
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Animals", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.Animals", "BiteId", "dbo.Bites");
            DropIndex("dbo.Animals", new[] { "BreedId" });
            DropIndex("dbo.Animals", new[] { "SpeciesId" });
            DropIndex("dbo.Animals", new[] { "VetId" });
            DropIndex("dbo.Animals", new[] { "BiteId" });
            DropIndex("dbo.AnimalOwners", new[] { "Animal_Id" });
            DropIndex("dbo.AnimalOwners", new[] { "StateId" });
            DropIndex("dbo.AnimalOwners", new[] { "CityId" });
            DropTable("dbo.Animals");
            DropTable("dbo.AnimalOwners");
        }
    }
}
