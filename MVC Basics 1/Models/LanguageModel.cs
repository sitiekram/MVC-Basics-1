using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class LanguageModel
    {
        [Key]
        public int LanguageID { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public List<People_LanguageModel> PeopleLanguages { get; set; }

    }
}

