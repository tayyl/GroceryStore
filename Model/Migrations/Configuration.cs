namespace Model.Migrations
{
    using Model.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.IO;
    using System.Collections.ObjectModel;

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
            context.CartItems.RemoveRange(context.CartItems.ToArray());
            context.Carts.RemoveRange(context.Carts.ToArray());
            context.Nutrients.RemoveRange(context.Nutrients.ToArray());
            context.Prices.RemoveRange(context.Prices.ToArray());
            context.Shops.RemoveRange(context.Shops.ToArray());
            context.Products.RemoveRange(context.Products.ToArray());

            Nutrient knutrient = new Nutrient
            {
                CalorifiValue = 436,
                Fat = 13,
                SaturatedFat = 0.8,
                Carbohydrate = 67,
                Sugar = 4.6,
                Fiber = 3.6,
                Protein = 11,
                Salt = 2.5
            };
            Price kprice = new Price
            {
                CreationDate = DateTime.Now,
                Value = 3.41m,
            };
            Nutrient anutrient = new Nutrient
            {
                CalorifiValue = 436,
                Fat = 13,
                SaturatedFat = 0.8,
                Carbohydrate = 67,
                Sugar = 4.6,
                Fiber = 3.6,
                Protein = 11,
                Salt = 2.5
            };
            Price aprice = new Price
            {
                CreationDate = DateTime.Now,
                Value = 1.49m,
            };
            Nutrient hnutrient = new Nutrient
            {
                CalorifiValue = 136,
                Fat = 3,
                SaturatedFat = 0.8,
                Carbohydrate = 57,
                Sugar = 46,
                Fiber = 5.6,
                Protein = 14,
                Salt = 2.8
            };
            Price hprice = new Price
            {
                CreationDate = DateTime.Now,
                Value = 2.29m,
            };
            Product krakersy = new Product
            {
                Id = 1,
                Barcode = 5900320003420,
                Description = " Junior Safari to produkt przygotowany przede wszystkim z myœl¹ o najm³odszych konsumentach, którzy preferuj¹ ³agodny smak przek¹sek. Weso³e kszta³ty zwierzaków zaciekawi¹ najm³odszych",
                Image = ReadImage("Migrations/junior.jpg"),
                Name = "Lajkonik Junior Safari krakersy",
                Nutrient = knutrient,
                Prices = new Collection<Price> { kprice },
                Type = "Przek¹ska"
            };
            kprice.Product = krakersy;
            kprice.Product = krakersy;
            context.Products.AddOrUpdate(krakersy);
            context.Nutrients.AddOrUpdate(knutrient);
            context.Prices.AddOrUpdate(kprice);
            context.SaveChanges();
            // ##################################################
            Product Arbuz = new Product
            {
                Id = 2,
                Barcode = 0803254003220,
                Description = " Arbuz, prawid³owo zwany kawonem, jest roœlin¹ jednoroczn¹, nale¿¹c¹ do rodziny dyniowatych (Cucurbitaceae).",
                Image = ReadImage("Migrations/arbuz.png"),
                Name = "Arbuz Zwyczajny (LUZ)",
                Nutrient = knutrient,
                Prices = new Collection<Price> { kprice },
                Type = "Owoc"
            };
            aprice.Product = Arbuz;
            aprice.Product = Arbuz;
            context.Products.AddOrUpdate(Arbuz);
            context.Nutrients.AddOrUpdate(anutrient);
            context.Prices.AddOrUpdate(aprice);
            context.SaveChanges();
            // ##################################################

            Product Hortex = new Product
            {
                Id = 3,
                Barcode = 5900500023220,
                Description = "Nektar wiœniowy Hortex to naturalny sok, stworzony z soku zagêszczonego. Doskonale smakuje na ch³odno, œwietnie orzeŸwia.",
                Image = ReadImage("Migrations/hortex.jpg"),
                Name = "Hortex Jab³ko Wiœnia",
                Nutrient = knutrient,
                Prices = new Collection<Price> { kprice },
                Type = "Napoje"
            };
            hprice.Product = Hortex;
                hprice.Product = Hortex;
                context.Products.AddOrUpdate(Hortex);
                context.Nutrients.AddOrUpdate(hnutrient);
                context.Prices.AddOrUpdate(hprice);
                context.SaveChanges();

            }
    private static byte[] ReadImage(string Path)
        {

            return File.ReadAllBytes(System.AppDomain.CurrentDomain.BaseDirectory + "../../" + Path);
        }
    }
}

