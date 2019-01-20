using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    public class CartConfiguration : EntityTypeConfiguration<Cart>
    {
        public CartConfiguration()
        {
            HasKey(x => x.ApplicationUserId);
            HasMany(x => x.Items).WithRequired(x => x.Cart).WillCascadeOnDelete();
        }
    }
}
