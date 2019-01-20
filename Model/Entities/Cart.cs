using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Model.Entities
{
    public class Cart
    {
        public virtual string ApplicationUserId { get; set; }
        public virtual ICollection<CartItem> Items { get; set; }
            = new Collection<CartItem> { };
    }
}