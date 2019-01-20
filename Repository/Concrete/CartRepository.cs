using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Repository.Concrete
{
    public class CartRepository : BaseRepository, ICartsRepository
    {
        public Task<bool> DeleteCartAsync(Cart Cart)
        {
            throw new NotImplementedException();
        }

        //public async Task<Cart> GetCart(ApplicationUser applicationUser)
        //{
        //    Cart Cart = await context.Carts.FirstOrDefault(x => x.ApplicationUser == applicationUser);
        //    return Cart;
        //}

        public async Task<Cart> GetCart(string identityUserId)
        {
            Cart Cart = await context.Carts.FirstOrDefaultAsync(x => x.ApplicationUserId == identityUserId);
            return Cart;
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
                context.Entry(Cart).State = Cart.ApplicationUserId == default(string) ? EntityState.Added : EntityState.Modified;

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
