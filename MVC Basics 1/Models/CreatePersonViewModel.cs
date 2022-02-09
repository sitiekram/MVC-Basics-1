using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class CreatePersonViewModel
    {
        [Required(ErrorMessage = "Full Name is mandatory"), MinLength(5), MaxLength(20)]
        [Display(Name = "Full Name")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

        //[Required(ErrorMessage = "Please enter city."), MinLength(3), MaxLength(15)]
        //[Display(Name = "City")]
        //[DataType(DataType.Text)]
        //public string City { get; set; }

        [Required(ErrorMessage = "Phone number is mandatory")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        //public int CityId { get; set; }

        //public CityModel PersonCity { get; set; }

        //[Required]
        //public List<int> Languages { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Select a country")]
        public int CountryID { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Select a city")]
        public int CityID { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Format semms to be wrong")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
