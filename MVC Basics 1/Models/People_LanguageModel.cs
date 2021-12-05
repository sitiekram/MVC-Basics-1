using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class People_LanguageModel
    {
        public int PersonId { get; set; }
        public PeopleModel People { get; set; }

        public int LanguageID { get; set; }
        public LanguageModel Language { get; set; }
    }
}

