using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    [Authorize(Roles="Admin,User")]
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
            List<People_LanguageModel> ListOfPeopleLanguages = _context.PeopleLanguages.ToList();

            return View(ListOfPeopleLanguages);
        }

        public IActionResult EditLanguage(int languageid)
        {
            var languageData = _context.Languages.Where(x => x.LanguageID == languageid).FirstOrDefault();
            
            if(languageData != null)
            {
                TempData["LanguageID"] = languageid;
                TempData.Keep();
                return View(languageData);
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditLanguage(LanguageModel language)
        {
            int languageid = (int)TempData["LanguageID"];
            var languageData = _context.Languages.Where(x => x.LanguageID == languageid).FirstOrDefault();

            if (languageData != null)
            {
                languageData.Name = language.Name;
                languageData.Description = language.Description;
                _context.Entry(languageData).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Languages");
        }

        public IActionResult DeleteLanguage(int languageid)
        {
            if(languageid > 0)
            {
                var languagebyid = _context.Languages.Where(x => x.LanguageID == languageid).FirstOrDefault();
                if(languagebyid != null)
                {
                    _context.Entry(languagebyid).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Languages");
        }
    }
}
