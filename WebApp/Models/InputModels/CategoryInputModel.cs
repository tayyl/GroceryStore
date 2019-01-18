using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.InputModels
{
    public class CategoryInputModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}