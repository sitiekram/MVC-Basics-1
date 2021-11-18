
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
            PeopleViewModel peopleView = new PeopleViewModel();
            peopleView.PersonList=peopleView.Read();
            if(peopleView.PersonList.Count == 0 || peopleView.PersonList == null)
            {
                peopleView.SeedPeople();
            }
            return View(peopleView);
        }
        [HttpPost]
        public IActionResult Index(string filterString)
        {
            PeopleViewModel peopleView = new PeopleViewModel();
            PeopleViewModel filterPersonView = new PeopleViewModel();
            peopleView.PersonList = peopleView.Read();
            filterPersonView.PersonList = new List<Person>();
            if (filterString == "" || filterString == null)
            {
                filterPersonView.PersonList = peopleView.Read();
            }
            else
            {
                foreach (var person in peopleView.PersonList)
                {

                    if (person.FullName.Contains(filterString) || person.City.Contains(filterString))
                    {
                        filterPersonView.PersonList.Add(person);
                    }
                }
            }
            return View(filterPersonView);
        }
        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel createPerson)
        {
            PeopleViewModel peopleView = new PeopleViewModel();
            if (ModelState.IsValid)
            {
                peopleView.FullName = createPerson.FullName;
                peopleView.City = createPerson.City;
                peopleView.PhoneNumber = createPerson.PhoneNumber;
                peopleView.Email = createPerson.Email;
               peopleView.PersonList = peopleView.Read();
                peopleView.Create(createPerson.FullName, createPerson.City, createPerson.PhoneNumber, createPerson.Email);
                ViewBag.Message = "Successfully added person!";
                return View("Index",peopleView);
            }
            ViewBag.Message = "Failed to add person";
            return View("Index",peopleView);
        }
        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            PeopleViewModel peopleView = new PeopleViewModel();
            Person DeletePerson = peopleView.Read(id);
            bool status=peopleView.Delete(DeletePerson);
            if (status)
            {
                ViewBag.Message = "Successfully deleted person!";
            }
            else
            {
                ViewBag.Message = "Failed to delete the person";
            }
            return RedirectToAction("Index");
        }
    }
}
