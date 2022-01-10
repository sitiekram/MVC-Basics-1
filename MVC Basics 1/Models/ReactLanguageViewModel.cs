using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class ReactLanguageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ReactLanguageViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
