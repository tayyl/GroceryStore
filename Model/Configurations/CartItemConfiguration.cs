
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.IO;
using System.Linq;
using System.Text;

namespace Model.Configurations
{
    public class CartItemConfiguration : EntityTypeConfiguration<CartItem>
    {
        public CartItemConfiguration()
        {
            //HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasRequired(t => t.Cart).WithMany(c => c.CartItems).HasForeignKey(t => t.CartId).WillCascadeOnDelete(true);
        }
    }
}