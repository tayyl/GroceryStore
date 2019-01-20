using Microsoft.AspNet.Identity.EntityFramework;
using Model.Configurations;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using static Model.AppContext;

namespace Model
{  // Możesz dodać dane profilu dla użytkownika, dodając więcej właściwości do klasy ApplicationUser. Odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=317594, aby dowiedzieć się więcej.


    public class AppContext : IdentityDbContext<ApplicationUser>
    {
        public class ApplicationUser : IdentityUser
        {
            public int CartId { get; set; }
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Dodaj tutaj niestandardowe oświadczenia użytkownika
                return userIdentity;
            }
        }

        //ublic DbSet<Category> Categories { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public AppContext() : base("AppConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ShopConfiguration());
            modelBuilder.Configurations.Add(new NutrientConfiguration());
            modelBuilder.Configurations.Add(new PriceConfiguration());
            modelBuilder.Configurations.Add(new CartConfiguration());
            modelBuilder.Configurations.Add(new CartItemConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        public static AppContext Create()
        {
            return new AppContext();
        }
    }
}
