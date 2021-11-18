using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            PeopleMemory peopleMemory = new PeopleMemory();

            PeopleViewModel peopleListViewModel = new PeopleViewModel() { PersonList = peopleMemory.Read() };
            if (peopleListViewModel.PersonList.Count == 0 || peopleListViewModel.PersonList == null)
            {
                peopleMemory.SeedPeople();
            }
            return View(peopleListViewModel);
        }
    }
}
