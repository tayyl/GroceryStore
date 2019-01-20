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
            public async Task<bool> DeleteCartItemAsync(CartItem CartItem)
            {
            if (CartItem == null)
                return false;
            context.CartItems.Remove(CartItem);

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

            //public async Task<CartItem> GetCartItem(ApplicationUser applicationUser)
            //{
            //    CartItem CartItem = await context.CartItems.FirstOrDefault(x => x.ApplicationUser == applicationUser);
            //    return CartItem;
            //}

            public CartItem GetCartItem(int Id)
            {
                CartItem CartItem = context.CartItems.FirstOrDefault(x => x.Id == Id);

                return CartItem;
            }
            public async Task<CartItem> GetCartItemAsyncProduct(int productId)
            {
                CartItem cartItem = await context.CartItems.FirstOrDefaultAsync(x => x.Product.Id == productId);
                return cartItem;
            }
            public async Task<CartItem> GetCartItemAsync(int CartId)
            {
                CartItem CartItem = await context.CartItems.FirstOrDefaultAsync(x => x.Id == CartId);

                return CartItem;
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


