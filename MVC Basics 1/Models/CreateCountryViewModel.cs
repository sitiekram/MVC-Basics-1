using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class CreateCountryViewModel
    {
        [Required]
        [Display(Name = "Country Name")]
        [MaxLength(100)]
        public string CountryName { get; set; }
    }
}
