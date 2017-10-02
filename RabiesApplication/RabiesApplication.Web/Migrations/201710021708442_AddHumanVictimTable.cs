namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHumanVictimTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HumanVictims",
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bites", t => t.BiteId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Counties", t => t.CountyId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.BiteId)
                .Index(t => t.CityId)
                .Index(t => t.CountyId)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HumanVictims", "StateId", "dbo.States");
            DropForeignKey("dbo.HumanVictims", "CountyId", "dbo.Counties");
            DropForeignKey("dbo.HumanVictims", "CityId", "dbo.Cities");
            DropForeignKey("dbo.HumanVictims", "BiteId", "dbo.Bites");
            DropIndex("dbo.HumanVictims", new[] { "StateId" });
            DropIndex("dbo.HumanVictims", new[] { "CountyId" });
            DropIndex("dbo.HumanVictims", new[] { "CityId" });
            DropIndex("dbo.HumanVictims", new[] { "BiteId" });
            DropTable("dbo.HumanVictims");
        }
    }
}
