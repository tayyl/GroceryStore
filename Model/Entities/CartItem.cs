using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Amount { get; set; } = 1;
        public virtual Product Product { get; set; }

        public virtual Cart Cart { get; set;  }
        public CartItem(Product product)
        {
            Product = product;
        }
    }
}
