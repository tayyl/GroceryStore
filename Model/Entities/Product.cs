﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public long Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Price> Prices { get; set; } = new List<Price> {  };
        //public int NutrientId { get; set; }
        public virtual Nutrient Nutrient { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
    }
}
