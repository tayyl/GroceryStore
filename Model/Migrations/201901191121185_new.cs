namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserBinItems", newName: "Carts");
            AddColumn("dbo.AspNetUsers", "Cart_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Carts", "BinId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Cart_Id");
            AddForeignKey("dbo.AspNetUsers", "Cart_Id", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.AspNetUsers", new[] { "Cart_Id" });
            AlterColumn("dbo.Carts", "BinId", c => c.String());
            DropColumn("dbo.AspNetUsers", "Cart_Id");
            RenameTable(name: "dbo.Carts", newName: "UserBinItems");
        }
    }
}
