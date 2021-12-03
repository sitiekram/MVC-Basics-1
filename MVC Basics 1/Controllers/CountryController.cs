using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Countries()
        {
            List<CountryModel> ListOfCountries = _context.Countries.ToList();
            return View(ListOfCountries);
        }

        public IActionResult CreateCountry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCountry(CountryModel country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
                return RedirectToAction("Countries");
            }
            return View();
        }
    }
}
