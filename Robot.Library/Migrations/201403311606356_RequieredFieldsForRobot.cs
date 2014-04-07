namespace Robot.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequieredFieldsForRobot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RobotEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Place = c.String(nullable: false, maxLength: 10),
                        Identification = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RobotEntities");
        }
    }
}
