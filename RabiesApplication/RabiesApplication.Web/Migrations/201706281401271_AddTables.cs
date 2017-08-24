namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RowVersion = c.Binary(),
                        ActionType = c.String(nullable: false),
                        BiteId = c.String(maxLength: 128),
                        Comments = c.String(nullable: false),
                        EmployeecreatedId = c.String(),
                        EmployeeeditedId = c.String(),
                        Recordcreated = c.DateTimeOffset(nullable: false, precision: 7),
                        Recordedited = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bites", t => t.BiteId)
                .Index(t => t.BiteId);
            
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RowVersion = c.Binary(),
                        BiteId = c.String(maxLength: 128),
                        VetId = c.String(maxLength: 128),
                        IsVictim = c.Boolean(nullable: false),
                        SpeciesId = c.String(maxLength: 128),
                        BreedId = c.String(maxLength: 128),
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
                        EmployeecreatedId = c.String(),
                        EmployeeeditedId = c.String(),
                        Recordcreated = c.DateTimeOffset(nullable: false, precision: 7),
                        Recordedited = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bites", t => t.BiteId)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .ForeignKey("dbo.Species", t => t.SpeciesId)
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
                        RowVersion = c.Binary(),
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
                        RowVersion = c.Binary(),
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
                        RowVersion = c.Binary(),
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
            
            CreateTable(
                "dbo.HumanVictims",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RowVersion = c.Binary(),
                        BiteId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Dateofbirth = c.DateTimeOffset(precision: 7),
                        Age = c.Int(),
                        Addressline1 = c.String(),
                        Addressline2 = c.String(),
                        CityId = c.String(),
                        CountyId = c.String(),
                        StateId = c.String(),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bites", t => t.BiteId)
                .Index(t => t.BiteId);
            
            CreateTable(
                "dbo.Investigations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RowVersion = c.Binary(),
                        BiteId = c.String(maxLength: 128),
                        QuarantineLetterSent = c.String(),
                        LetterSentDate = c.DateTime(nullable: false),
                        FollowUpDays = c.Int(nullable: false),
                        InvestigationCompletionDate = c.DateTime(),
                        ReportClosedDate = c.DateTime(),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bites", t => t.BiteId)
                .Index(t => t.BiteId);
            
            CreateTable(
                "dbo.PetOwners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RowVersion = c.Binary(),
                        AnimalId = c.String(maxLength: 128),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.AnimalId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.AnimalId)
                .Index(t => t.CityId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Specimen",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RowVersion = c.Binary(),
                        AnimalId = c.Int(nullable: false),
                        SpeciesId = c.Int(nullable: false),
                        SubmittedBy = c.String(),
                        DateReceived = c.DateTime(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        CityId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        AgencyTest = c.String(),
                        Reason = c.String(),
                        Result = c.String(),
                        SubAgency = c.String(),
                        SubCity = c.String(),
                        SubPhone = c.String(),
                        Comments = c.String(),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                        Animal_Id = c.String(maxLength: 128),
                        City_Id = c.String(maxLength: 128),
                        Species_Id = c.String(maxLength: 128),
                        State_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.Animal_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Species", t => t.Species_Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.Animal_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Species_Id)
                .Index(t => t.State_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specimen", "State_Id", "dbo.States");
            DropForeignKey("dbo.Specimen", "Species_Id", "dbo.Species");
            DropForeignKey("dbo.Specimen", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Specimen", "Animal_Id", "dbo.Animals");
            DropForeignKey("dbo.PetOwners", "StateId", "dbo.States");
            DropForeignKey("dbo.PetOwners", "CityId", "dbo.Cities");
            DropForeignKey("dbo.PetOwners", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Investigations", "BiteId", "dbo.Bites");
            DropForeignKey("dbo.HumanVictims", "BiteId", "dbo.Bites");
            DropForeignKey("dbo.Animals", "VetId", "dbo.Vets");
            DropForeignKey("dbo.Vets", "StateId", "dbo.States");
            DropForeignKey("dbo.Vets", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Animals", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.Animals", "BiteId", "dbo.Bites");
            DropForeignKey("dbo.Actions", "BiteId", "dbo.Bites");
            DropIndex("dbo.Specimen", new[] { "State_Id" });
            DropIndex("dbo.Specimen", new[] { "Species_Id" });
            DropIndex("dbo.Specimen", new[] { "City_Id" });
            DropIndex("dbo.Specimen", new[] { "Animal_Id" });
            DropIndex("dbo.PetOwners", new[] { "StateId" });
            DropIndex("dbo.PetOwners", new[] { "CityId" });
            DropIndex("dbo.PetOwners", new[] { "AnimalId" });
            DropIndex("dbo.Investigations", new[] { "BiteId" });
            DropIndex("dbo.HumanVictims", new[] { "BiteId" });
            DropIndex("dbo.Vets", new[] { "StateId" });
            DropIndex("dbo.Vets", new[] { "CityId" });
            DropIndex("dbo.Animals", new[] { "BreedId" });
            DropIndex("dbo.Animals", new[] { "SpeciesId" });
            DropIndex("dbo.Animals", new[] { "VetId" });
            DropIndex("dbo.Animals", new[] { "BiteId" });
            DropIndex("dbo.Actions", new[] { "BiteId" });
            DropTable("dbo.Specimen");
            DropTable("dbo.PetOwners");
            DropTable("dbo.Investigations");
            DropTable("dbo.HumanVictims");
            DropTable("dbo.Vets");
            DropTable("dbo.Species");
            DropTable("dbo.Breeds");
            DropTable("dbo.Animals");
            DropTable("dbo.Actions");
        }
    }
}
