using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    [Authorize(Roles ="Admin, User")]
    public class PeopleNewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleNewController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult People()
        {
            List<PeopleModel> ListOfPeople = _context.People.ToList();
            return View(ListOfPeople);
        }
        public IActionResult CreatePerson()
        {
            ViewBag.CityID = _context.Cities.Select(a => new SelectListItem
            {
                Text = (a.ID).ToString(),
                Value = (a.ID).ToString()
            }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreatePerson(PeopleModel person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction("People");
            }
            return View();
        }
        
        public IActionResult EditPerson(int personId)
        {
            var personData = _context.People.Where(x => x.PersonId == personId).FirstOrDefault();
            if(personData != null)
            {
                ViewBag.CityID = _context.Cities.Select(a => new SelectListItem
                {
                    Text = (a.ID).ToString(),
                    Value = (a.ID).ToString()
                }).ToList();
                TempData["PersonID"] = personId;
                TempData.Keep();
                return View(personData);
             }

            return View();
        }

        [HttpPost]
        public IActionResult EditPerson(PeopleModel person)
        {
            int personId = (int)TempData["PersonID"];
            var personData = _context.People.Where(x => x.PersonId == personId).FirstOrDefault();
            if(personData != null)
            {
                personData.FullName = person.FullName;
                personData.PhoneNumber = person.PhoneNumber;
                personData.Email = person.Email;
                personData.CityID = person.CityID;
                _context.Entry(personData).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("People");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeletePerson(int personId)
        {
            if (personId > 0)
            {
                var personbyId = _context.People.Where(x => x.PersonId == personId).FirstOrDefault();
                if (personbyId != null)
                {
                    _context.Entry(personbyId).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("People");
        }
    }
}
