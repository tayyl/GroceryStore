﻿
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    public class PriceConfiguration : EntityTypeConfiguration<Price>
    {
        public PriceConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            //Property(x => x.Amount);
        }
    }
}
