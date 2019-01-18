using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public async Task<bool> DeleteProductAsync(Product Product)
        {
            if (Product == null)
                return false;
            context.Products.Remove(Product);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var Products = await context.Products.ToListAsync();

            return Products;
        }

        public async Task<Product> GetProduct(int id)
        {
            Product Product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return Product;
        }

        public async Task<bool> SaveProductAsync(Product Product)
        {
            if (Product == null)
                return false;
            try
            {
                context.Entry(Product).State = Product.Id == default(int) ? EntityState.Added : EntityState.Modified;

                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
