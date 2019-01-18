namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nutrients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CalorifiValue = c.Double(nullable: false),
                        Fat = c.Double(nullable: false),
                        SaturatedFat = c.Double(nullable: false),
                        Carbohydrate = c.Double(nullable: false),
                        Sugar = c.Double(nullable: false),
                        Fiber = c.Double(nullable: false),
                        Protein = c.Double(nullable: false),
                        Salt = c.Double(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Barcode = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                        Image = c.Binary(),
                        Type = c.String(),
                        PriceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Shop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.Shop_Id)
                .Index(t => t.Shop_Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Product_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.ProductPrices",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Price_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Price_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Prices", t => t.Price_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Price_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.ProductPrices", "Price_Id", "dbo.Prices");
            DropForeignKey("dbo.ProductPrices", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Nutrients", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductPrices", new[] { "Price_Id" });
            DropIndex("dbo.ProductPrices", new[] { "Product_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Product_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Order_Id" });
            DropIndex("dbo.Prices", new[] { "Shop_Id" });
            DropIndex("dbo.Nutrients", new[] { "Product_Id" });
            DropTable("dbo.ProductPrices");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Shops");
            DropTable("dbo.Prices");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Nutrients");
        }
    }
}
