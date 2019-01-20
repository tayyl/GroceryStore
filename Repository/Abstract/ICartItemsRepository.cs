using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface ICartItemsRepository
    {
        Task<CartItem> GetCartItem(int Id);
        Task<CartItem> GetCartItemAsyncProduct(int productId);
        Task<List<CartItem>> GetCartItemsAsync(int CartId);
        Task<bool> SaveCartItemAsync(CartItem product);
        Task<bool> DeleteCartItemAsync(CartItem product);

    }
}
