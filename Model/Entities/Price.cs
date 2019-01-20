using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Product Product { get; set; }
    }
}
