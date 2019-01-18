using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.InputModels.Home
{
    public class HomeInputModel
    {
        /// <summary>
        /// Identyfikator
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Nazwa elementu
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }
    }
}