﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.InputModels
{
    public class ProductInputModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int Barcode { get; set; }
        public string Type { get; set; }
        public string Description { get; set; } 
    }
}