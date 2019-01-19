namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.AspNetUsers", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.AspNetUsers", new[] { "Cart_Id" });
            DropIndex("dbo.Carts", new[] { "Product_Id" });
            AddColumn("dbo.Products", "Image", c => c.Binary());
            DropColumn("dbo.AspNetUsers", "Cart_Id");
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        BinId = c.Int(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Cart_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Products", "Image");
            CreateIndex("dbo.Carts", "Product_Id");
            CreateIndex("dbo.AspNetUsers", "Cart_Id");
            AddForeignKey("dbo.AspNetUsers", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.Carts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
