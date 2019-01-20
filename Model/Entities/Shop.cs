using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
