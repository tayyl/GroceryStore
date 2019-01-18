namespace Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Categories.Any(x => x.Name == "Category 1"))
            {
                context.Categories.Add(new Entities.Category()
                {
                    Name = "Category 1"
                });
                context.SaveChanges();
            }
            if (!context.Products.Any(x => x.Name == "Produkt 1"))
            {
                context.Products.Add(new Entities.Product()
                {
                    Name = "Produkt 1",
                    Price = 15m,
                    CategoryId = 1
                });
            }
            context.SaveChanges();
                
            
        }
    }
}
