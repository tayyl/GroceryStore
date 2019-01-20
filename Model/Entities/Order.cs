using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
