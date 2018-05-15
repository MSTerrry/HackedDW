namespace DW.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbDeliveryRquests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Filled = c.DateTime(nullable: false),
                        FullName = c.String(),
                        TimeDeliver = c.DateTime(nullable: false),
                        ClientAddress = c.String(),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbWayPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceTitle = c.String(),
                        Address = c.String(),
                        ShopType = c.String(),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DbDeliveryRquest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbDeliveryRquests", t => t.DbDeliveryRquest_Id)
                .Index(t => t.DbDeliveryRquest_Id);
            
            CreateTable(
                "dbo.DbProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Single(nullable: false),
                        Additions = c.String(),
                        Cost = c.Single(nullable: false),
                        DbWayPoint_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbWayPoints", t => t.DbWayPoint_Id)
                .Index(t => t.DbWayPoint_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbWayPoints", "DbDeliveryRquest_Id", "dbo.DbDeliveryRquests");
            DropForeignKey("dbo.DbProducts", "DbWayPoint_Id", "dbo.DbWayPoints");
            DropIndex("dbo.DbProducts", new[] { "DbWayPoint_Id" });
            DropIndex("dbo.DbWayPoints", new[] { "DbDeliveryRquest_Id" });
            DropTable("dbo.DbProducts");
            DropTable("dbo.DbWayPoints");
            DropTable("dbo.DbDeliveryRquests");
        }
    }
}
