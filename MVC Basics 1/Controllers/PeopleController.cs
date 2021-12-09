using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class PeopleController : Controller
    {
        
         public IActionResult Index()
         {
             PeopleMemory peopleMemory = new PeopleMemory();
             PeopleViewModel peopleView = new PeopleViewModel() { PersonList = peopleMemory.Read() };
             if (peopleView.PersonList.Count == 0 || peopleView.PersonList == null)
             {
                 peopleMemory.SeedPeople();
             }
             return View(peopleView);
         }

         [HttpPost]
         public IActionResult Index(string filterString)
         {
             PeopleMemory peopleMemory = new PeopleMemory();
             PeopleViewModel filterPersonView = new PeopleViewModel();
             filterPersonView.PersonList = new List<Person>();
             if (filterString == "" || filterString == null)
             {
                 filterPersonView.PersonList = peopleMemory.Read();
             }
             else
             {
                 foreach (var person in peopleMemory.Read())
                 {

                     if (person.FullName.Contains(filterString, StringComparison.OrdinalIgnoreCase) || person.City.Contains(filterString, StringComparison.OrdinalIgnoreCase))
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
             PeopleMemory peopleMemory = new PeopleMemory();
             if (ModelState.IsValid)
             {
                 peopleView.FullName = createPerson.FullName;
                 peopleView.City = createPerson.City;
                 peopleView.PhoneNumber = createPerson.PhoneNumber;
                 peopleView.Email = createPerson.Email;
                 peopleView.PersonList = peopleMemory.Read();
                 peopleMemory.Create(createPerson.FullName, createPerson.City, createPerson.PhoneNumber, createPerson.Email);
                 ViewBag.Message = "Successfully added person!";
                 return View("Index", peopleView);
             }
             ViewBag.Message = "Failed to add person" + ModelState.Values;
             return View("Index", peopleView);
         }
         public IActionResult DeletePerson(int id)
         {
             PeopleMemory peopleMemory = new PeopleMemory();
             Person DeletePerson = peopleMemory.Read(id);
             bool status = peopleMemory.Delete(DeletePerson);
             return RedirectToAction("Index");
         }
    }
}