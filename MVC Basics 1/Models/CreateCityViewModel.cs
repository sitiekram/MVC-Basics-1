using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    //public class CreateCityViewModel
    //{
    //    [Required]
    //    [DisplayName("City Name")]
    //    public string Name { get; set; }

    //    [Required]
    //    [DisplayName("Country ")]
    //    public string CountryCode { get; set; }

    //    [Required]
    //    public int Population { get; set; }
    //}
    public class CreateCityViewModel
    {
        [Required]
        [Display(Name = "City Name")]
        [MaxLength(100)]
        public string CityName { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryID { get; set; }

        public List<CountryModel> AvailableCountries { get; set; }
    }
}
