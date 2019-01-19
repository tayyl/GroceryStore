namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart_new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Cart_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "Cart_Id");
            AddForeignKey("dbo.Products", "Cart_Id", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            DropColumn("dbo.Products", "Cart_Id");
            DropTable("dbo.Carts");
        }
    }
}
