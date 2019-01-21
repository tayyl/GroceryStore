using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Product Product { get; set; }
    }
}
