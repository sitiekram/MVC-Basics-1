using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class ReactCityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ReactCityViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
