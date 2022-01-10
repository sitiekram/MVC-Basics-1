using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Basics_1.Models
{
    public class ReactPeopleViewModel
    {
        [Key]
        [Display(Name = "ID")]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        public string CityName { get; set; }

        public List<ReactLanguageViewModel> Languages { get; set; }
        
        public ReactPeopleViewModel(int id, string name, string cityName, List<ReactLanguageViewModel> languages)
        {
            PersonId = id;
            Name = name;
            CityName = cityName;
            Languages = languages;
        }
    }
}
