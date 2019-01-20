using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class CartItemsRepository : BaseRepository, ICartItemsRepository
        {
            public Task<bool> DeleteCartItemAsync(CartItem CartItem)
            {
                throw new NotImplementedException();
            }

            //public async Task<CartItem> GetCartItem(ApplicationUser applicationUser)
            //{
            //    CartItem CartItem = await context.CartItems.FirstOrDefault(x => x.ApplicationUser == applicationUser);
            //    return CartItem;
            //}

            public async Task<CartItem> GetCartItem(int Id)
            {
                CartItem CartItem = await context.CartItems.FirstOrDefaultAsync(x => x.Id == Id);

                return CartItem;
            }
            public async Task<CartItem> GetCartItemAsyncProduct(int productId)
        {
            CartItem cartItem = await context.CartItems.FirstOrDefaultAsync(x => x.Product.Id == productId);
            return cartItem;
        }
            public Task<List<CartItem>> GetCartItemsAsync(int CartId)
            {
                throw new NotImplementedException();
            }

            public async Task<bool> SaveCartItemAsync(CartItem CartItem)
            {
                if (CartItem == null)
                    return false;
                try
                {
                    context.Entry(CartItem).State = CartItem.Id == default(int) ? EntityState.Added : EntityState.Modified;
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


