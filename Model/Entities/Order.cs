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
        public string Number { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
