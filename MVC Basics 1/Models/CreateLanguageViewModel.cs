using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class CreateLanguageViewModel
    {
        [Required]
        [DisplayName("Language")]
        public string Name { get; set; }
    }
}
