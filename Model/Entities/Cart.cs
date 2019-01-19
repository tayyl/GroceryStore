using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Model.Entities
{
    public class Cart
    {
        public string Id { get; set;}
        public virtual ICollection<Product> Products { get; set; }
    }
}