namespace Robot.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseModelImplementation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        RobotId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RobotEntities", t => t.RobotId, cascadeDelete: true)
                .Index(t => t.RobotId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "RobotId", "dbo.RobotEntities");
            DropForeignKey("dbo.Instructions", "PartId", "dbo.Parts");
            DropIndex("dbo.Parts", new[] { "RobotId" });
            DropIndex("dbo.Instructions", new[] { "PartId" });
            DropTable("dbo.Parts");
            DropTable("dbo.Instructions");
        }
    }
}
