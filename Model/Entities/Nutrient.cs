using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Nutrient
    {
        public int Id { get; set; }
        public double CalorifiValue { get; set; }
        public double Fat { get; set; }
        public double SaturatedFat { get; set; }
        public double Carbohydrate { get; set; }
        public double Sugar { get; set; }
        public double Fiber { get; set; }
        public double Protein { get; set; }
        public double Salt { get; set; }

        public virtual Product Product { get; set; }
    }
}
