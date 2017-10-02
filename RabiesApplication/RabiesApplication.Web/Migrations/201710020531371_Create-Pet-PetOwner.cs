namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePetPetOwner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetOwners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BiteId = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Dateofbirth = c.DateTimeOffset(precision: 7),
                        Age = c.Int(),
                        Addressline1 = c.String(),
                        Addressline2 = c.String(),
                        CityId = c.String(maxLength: 128),
                        CountyId = c.String(maxLength: 128),
                        StateId = c.String(maxLength: 128),
                        Zipcode = c.Int(nullable: false),
                        Contactnumber1 = c.String(),
                        Contactnumber2 = c.String(),
                        BiteType = c.Boolean(nullable: false),
                        BiteTypeNonBite = c.Boolean(nullable: false),
                        PostExposureProphylaxis = c.Boolean(nullable: false),
                        MedicalTreatmentProvider = c.String(),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                        Pet_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bites", t => t.BiteId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Counties", t => t.CountyId)
                .ForeignKey("dbo.Pets", t => t.Pet_Id)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.BiteId)
                .Index(t => t.CityId)
                .Index(t => t.CountyId)
                .Index(t => t.StateId)
                .Index(t => t.Pet_Id);
            
            CreateTable(
                "dbo.Pets",
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
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                        Comments = c.String(),
                        Active = c.Boolean(nullable: false),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetOwners", "StateId", "dbo.States");
            DropForeignKey("dbo.PetOwners", "Pet_Id", "dbo.Pets");
            DropForeignKey("dbo.Pets", "VetId", "dbo.Vets");
            DropForeignKey("dbo.Vets", "StateId", "dbo.States");
            DropForeignKey("dbo.Vets", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Pets", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Pets", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.Pets", "BiteId", "dbo.Bites");
            DropForeignKey("dbo.PetOwners", "CountyId", "dbo.Counties");
            DropForeignKey("dbo.PetOwners", "CityId", "dbo.Cities");
            DropForeignKey("dbo.PetOwners", "BiteId", "dbo.Bites");
            DropIndex("dbo.Vets", new[] { "StateId" });
            DropIndex("dbo.Vets", new[] { "CityId" });
            DropIndex("dbo.Pets", new[] { "BreedId" });
            DropIndex("dbo.Pets", new[] { "SpeciesId" });
            DropIndex("dbo.Pets", new[] { "VetId" });
            DropIndex("dbo.Pets", new[] { "BiteId" });
            DropIndex("dbo.PetOwners", new[] { "Pet_Id" });
            DropIndex("dbo.PetOwners", new[] { "StateId" });
            DropIndex("dbo.PetOwners", new[] { "CountyId" });
            DropIndex("dbo.PetOwners", new[] { "CityId" });
            DropIndex("dbo.PetOwners", new[] { "BiteId" });
            DropTable("dbo.Vets");
            DropTable("dbo.Species");
            DropTable("dbo.Breeds");
            DropTable("dbo.Pets");
            DropTable("dbo.PetOwners");
        }
    }
}
