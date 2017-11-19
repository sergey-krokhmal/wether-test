namespace WeatherEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Weathers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Wether_Type = c.String(nullable: false, unicode: false),
                        Id_City = c.Int(nullable: false),
                        Temperature = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.Id_City, cascadeDelete: true)
                .Index(t => t.Id_City);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weathers", "Id_City", "dbo.Cities");
            DropIndex("dbo.Weathers", new[] { "Id_City" });
            DropTable("dbo.Weathers");
            DropTable("dbo.Cities");
        }
    }
}
