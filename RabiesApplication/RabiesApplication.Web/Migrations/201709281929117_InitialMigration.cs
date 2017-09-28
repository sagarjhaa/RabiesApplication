namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bites",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CityId = c.String(maxLength: 128),
                        StateId = c.String(maxLength: 128),
                        BiteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        BiteReportDate = c.DateTimeOffset(nullable: false, precision: 7),
                        BiteReportedBy = c.String(),
                        BiteStatusId = c.String(maxLength: 128),
                        Comments = c.String(),
                        EmployeeAssignedId = c.String(),
                        Active = c.Boolean(nullable: false),
                        InvestigationCompletionDate = c.DateTime(),
                        ReportClosedDate = c.DateTime(),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BiteStatus", t => t.BiteStatusId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.StateId)
                .Index(t => t.BiteStatusId);
            
            CreateTable(
                "dbo.BiteStatus",
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
                "dbo.Cities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CityName = c.String(nullable: false),
                        CountyId = c.String(maxLength: 128),
                        StateId = c.String(maxLength: 128),
                        Active = c.Boolean(nullable: false),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Counties", t => t.CountyId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CountyId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Fips = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        StateId = c.String(maxLength: 128),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StateName = c.String(nullable: false),
                        StateShortName = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        OrganizationId = c.String(maxLength: 128),
                        Phone = c.String(),
                        Extension = c.String(),
                        MobilePhone = c.String(),
                        Website = c.String(),
                        HouseNumber = c.String(),
                        StreetPrefix = c.String(),
                        StreetName = c.String(),
                        StreetSuffix = c.String(),
                        Address2 = c.String(),
                        CityName = c.String(),
                        StateAbbreviation = c.String(),
                        Zip5 = c.String(),
                        Zip4 = c.String(),
                        Active = c.Boolean(nullable: false),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        StreetAddress1 = c.String(nullable: false),
                        StreetAddress2 = c.String(),
                        Suite = c.String(),
                        City = c.String(nullable: false),
                        StateProvince = c.String(nullable: false),
                        PostalCode = c.String(),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Bites", "StateId", "dbo.States");
            DropForeignKey("dbo.Bites", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.Cities", "CountyId", "dbo.Counties");
            DropForeignKey("dbo.Counties", "StateId", "dbo.States");
            DropForeignKey("dbo.Bites", "BiteStatusId", "dbo.BiteStatus");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Employees", new[] { "OrganizationId" });
            DropIndex("dbo.Employees", new[] { "Id" });
            DropIndex("dbo.Counties", new[] { "StateId" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropIndex("dbo.Cities", new[] { "CountyId" });
            DropIndex("dbo.Bites", new[] { "BiteStatusId" });
            DropIndex("dbo.Bites", new[] { "StateId" });
            DropIndex("dbo.Bites", new[] { "CityId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Organizations");
            DropTable("dbo.Employees");
            DropTable("dbo.States");
            DropTable("dbo.Counties");
            DropTable("dbo.Cities");
            DropTable("dbo.BiteStatus");
            DropTable("dbo.Bites");
        }
    }
}
