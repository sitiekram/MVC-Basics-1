using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class CityModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set;}

        [Required]
        [MaxLength(3)]
        public string CountryCode { get; set;}

        [Required]
        public int Population { get; set; }

        public CountryModel Country { get; set; }

        public List<PeopleModel> People { get; set; }
    }
}
