using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    public class PersonAjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetPeople()
        {
            PeopleViewModel peopleView = new PeopleViewModel();
            peopleView.PersonList = peopleView.Read();
            if (peopleView.PersonList.Count == 0 || peopleView.PersonList == null)
            {
                peopleView.SeedPeople();
            }
            List<Person> personList = peopleView.Read();
            return PartialView("_AjaxPersonPartial", personList);
        }
        [HttpPost]
        public IActionResult FindPersonById(int personID)
        {
            PeopleViewModel peopleView = new PeopleViewModel();
            Person targetPerson = peopleView.Read(personID);
            List<Person> personList = new List<Person>();
            if (targetPerson != null)
            {
                personList.Add(targetPerson);
            }
            return PartialView("_AjaxPersonPartial", personList);
        }
        [HttpPost]
        public IActionResult DeletePersonById(int personID)
        {
            PeopleViewModel peopleView = new PeopleViewModel();
            bool status = false;
            Person targetPerson = peopleView.Read(personID);
            if (targetPerson != null)
            {
                status = peopleView.Delete(targetPerson);
            }
            if (status)
            {
                return StatusCode(200);
            }
            return StatusCode(404);
        }
    }
}
