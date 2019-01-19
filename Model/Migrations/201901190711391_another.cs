namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class another : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserBinItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        BinId = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBinItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.UserBinItems", new[] { "Product_Id" });
            DropTable("dbo.UserBinItems");
        }
    }
}
