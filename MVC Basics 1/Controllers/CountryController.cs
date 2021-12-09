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
    [Authorize(Roles="Admin")]
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
        public IActionResult EditCountry(String countryCode)
        {
           var Countrydata = _context.Countries.Where(x => x.Code == countryCode).FirstOrDefault();
            if (Countrydata != null)
            {
                TempData["CountryCode"] = countryCode;
                TempData.Keep();
                return View(Countrydata);
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditCountry(CountryModel country)
        {
            String countryCode = (string)TempData["CountryCode"];
            var Countrydata = _context.Countries.Where(x => x.Code == countryCode).FirstOrDefault();
            if(Countrydata!=null)
            {
                Countrydata.Name = country.Name;
                Countrydata.Continent = country.Continent;
                Countrydata.Population = country.Population;
                _context.Entry(Countrydata).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Countries");
        }
        
         public IActionResult DeleteCountry(string countryCode)  
          {  
             if (countryCode != null || countryCode != "")  
             {
                var countrybyCode = _context.Countries.Where(x => x.Code == countryCode).FirstOrDefault();
        
                if (countrybyCode != null)  
                  {  
                     _context.Entry(countrybyCode).State = EntityState.Deleted;  
                     _context.SaveChanges();  
                  }  
              }  
              return RedirectToAction("Countries");  
           } 
         
         
    }
}
