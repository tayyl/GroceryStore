using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface ICartsRepository
    {
        Task<Cart> GetCart(int id);
        Task<List<Cart>> GetCartsAsync();
        Task<bool> SaveCartAsync(Cart product);
        Task<bool> DeleteCartAsync(Cart product);
    }
}
