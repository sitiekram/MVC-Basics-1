using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class PeopleViewModel : CreatePersonViewModel
    {
        public List<Person> PersonList { get; set; }
        public string FilterString { get; set; }
        public PeopleViewModel()
        {
            PersonList = new List<Person>();
        }
    }
}