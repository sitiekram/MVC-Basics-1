using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cities()
        {
            List<CityModel> ListOfCities = _context.Cities.ToList();
            return View(ListOfCities);
        }

        public IActionResult CreateCity()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCity(CityModel city)
        {
            if(ModelState.IsValid)
            {
                _context.Cities.Add(city);
                _context.SaveChanges();
                return RedirectToAction("Cities");
            }
            return View();
        }

    }
}
