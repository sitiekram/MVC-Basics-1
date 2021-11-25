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
            PeopleMemory peopleMemory = new PeopleMemory();
            List<Person> personList = peopleMemory.Read();
            if (personList.Count == 0 || personList == null)
            {
                peopleMemory.SeedPeople();
            }
            return PartialView("_AjaxPersonPartial", personList);
        }
        [HttpPost]
        public IActionResult FindPersonById(int personID)
        {
            PeopleMemory peopleMemory = new PeopleMemory();
            Person targetPerson = peopleMemory.Read(personID);
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
            PeopleMemory peopleMemory = new PeopleMemory();
            bool status = false;
            Person targetPerson = peopleMemory.Read(personID);
            if (targetPerson != null)
            {
                status = peopleMemory.Delete(targetPerson);
            }
            if (status)
            {
                return StatusCode(200);
            }
            return StatusCode(404);
        }
    }
}
