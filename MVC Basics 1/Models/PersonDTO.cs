using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string Email { get; set; }
        public List<string> Languages { get; set; }
    }
}
