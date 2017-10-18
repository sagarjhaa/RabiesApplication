namespace RabiesApplication.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateManyToManyBetweenBiteAndAnimal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalBites",
                c => new
                    {
                        Animal_Id = c.String(nullable: false, maxLength: 128),
                        Bite_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Animal_Id, t.Bite_Id })
                .ForeignKey("dbo.Animals", t => t.Animal_Id, cascadeDelete: false)
                .ForeignKey("dbo.Bites", t => t.Bite_Id, cascadeDelete: false)
                .Index(t => t.Animal_Id)
                .Index(t => t.Bite_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnimalBites", "Bite_Id", "dbo.Bites");
            DropForeignKey("dbo.AnimalBites", "Animal_Id", "dbo.Animals");
            DropIndex("dbo.AnimalBites", new[] { "Bite_Id" });
            DropIndex("dbo.AnimalBites", new[] { "Animal_Id" });
            DropTable("dbo.AnimalBites");
        }
    }
}
