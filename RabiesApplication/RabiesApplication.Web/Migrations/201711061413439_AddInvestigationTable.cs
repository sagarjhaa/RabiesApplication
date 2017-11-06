namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvestigationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Investigations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BiteId = c.String(maxLength: 128),
                        QuarantineLetterSent = c.String(),
                        LetterSentDate = c.DateTime(nullable: false),
                        FollowUpDays = c.Int(nullable: false),
                        RecordCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        RecordEdited = c.DateTimeOffset(precision: 7),
                        EmployeeCreatedId = c.String(),
                        EmployeeEditedId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bites", t => t.BiteId)
                .Index(t => t.BiteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Investigations", "BiteId", "dbo.Bites");
            DropIndex("dbo.Investigations", new[] { "BiteId" });
            DropTable("dbo.Investigations");
        }
    }
}
