using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
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
    }
}
