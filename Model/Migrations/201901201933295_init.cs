namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Nutrients", "Product_Id", "dbo.Products");
            AddForeignKey("dbo.Nutrients", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nutrients", "Product_Id", "dbo.Products");
            AddForeignKey("dbo.Nutrients", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
