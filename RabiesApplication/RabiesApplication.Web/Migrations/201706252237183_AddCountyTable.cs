namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Fips = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Counties", "StateId", "dbo.States");
            DropIndex("dbo.Counties", new[] { "StateId" });
            DropTable("dbo.Counties");
        }
    }
}
