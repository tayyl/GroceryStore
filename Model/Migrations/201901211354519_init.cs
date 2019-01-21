namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Barcode", c => c.Long(nullable: false));
            AlterColumn("dbo.Prices", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prices", "Value", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Barcode", c => c.Int(nullable: false));
        }
    }
}
