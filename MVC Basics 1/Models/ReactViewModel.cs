using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class ReactViewModel
    {
        public List<ReactPeopleViewModel> ReactPeopleVMList { get; set; }

        public List<ReactCityViewModel> CitiesList { get; set; }
    }
}
