using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string CountryId { get; set; }

    }
}
