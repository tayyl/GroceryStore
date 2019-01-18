using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCapp1.Models
{
    // Modele zwracane przez akcje elementu MeController.
    public class GetViewModel
    {
        public string Hometown { get; set; }
    }
}