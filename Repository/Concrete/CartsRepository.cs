using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Repository.Concrete
{
    class CartsRepository : BaseRepository, ICartsRepository
    {
        public Task<bool> DeleteCartAsync(Cart Cart)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCart(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> GetCartsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveCartAsync(Cart Cart)
        {
            if (Cart == null)
                return false;
            try
            {
                context.Entry(Cart).State = Cart.Id == default(string) ? EntityState.Added : EntityState.Modified;

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
