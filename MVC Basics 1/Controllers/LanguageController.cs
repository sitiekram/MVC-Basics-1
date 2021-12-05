using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Languages()
        {
            List<LanguageModel> ListOfLanguages = _context.Languages.ToList();
            
            return View(ListOfLanguages);
        }

        public IActionResult CreateLanguage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateLanguage(LanguageModel language)
        {
            if(ModelState.IsValid)
            {
                _context.Languages.Add(language);
                _context.SaveChanges();
                return RedirectToAction("Languages");
            }
            return View();
        }
        public IActionResult ListAllLanguagesAndPeople()
        {
            //List<LanguageModel> ListOfLanguages = _context.Languages.ToList();
            //List<PeopleModel> ListOfPeople = _context.People.ToList();
            List<People_LanguageModel> ListOfPeopleLanguages = _context.PeopleLanguages.ToList();

            return View(ListOfPeopleLanguages);
        }


    }
}
