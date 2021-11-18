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

        [Required(ErrorMessage = "Please enter city."), MinLength(3), MaxLength(15)]
        [Display(Name = "City")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required(ErrorMessage = "Phone number is mandatory")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Format semms to be wrong")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
