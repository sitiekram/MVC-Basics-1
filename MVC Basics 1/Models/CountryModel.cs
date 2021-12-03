using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class CountryModel
    {
         [Key]
         [MaxLength(3)]
        public string Code { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Continent { get; set; }

        [Required]
        public int Population { get; set; }

        public List<CityModel> Cities { get; set; }

    }
}
