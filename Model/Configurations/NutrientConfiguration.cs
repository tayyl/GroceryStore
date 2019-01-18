using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    public class NutrientConfiguration : EntityTypeConfiguration<Nutrient>
    {
        public NutrientConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
           /* Property(x => x.CalorifiValue); 
            Property(x => x.Fat);
            Property(x => x.SaturatedFat);
            Property(x => x.Carbohydrate);
            Property(x => x.Sugar);
            Property(x => x.Fiber);
            Property(x => x.Protein);
            Property(x => x.Salt);*/
            // HasOne(x => x.Products).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
