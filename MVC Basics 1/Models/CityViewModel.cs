using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class CityViewModel
    {
        public IEnumerable<CityModel> Cities { get; set; }
    }
}
