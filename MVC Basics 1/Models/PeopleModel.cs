using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class PeopleModel
    {
        [Key]
        [Display(Name = "ID")]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(15)]
        public string City { get; set; }

        [Required(ErrorMessage = "Phone number is mandatory")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Format semms to be wrong")]
        public string Email { get; set; }
    }
}
