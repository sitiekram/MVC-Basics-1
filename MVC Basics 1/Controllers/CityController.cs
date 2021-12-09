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
    [Authorize(Roles ="Admin")]
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
            ViewBag.CountryCode = _context.Countries.Select(a => new SelectListItem
            {
                Text = a.Code, 
                Value = a.Code 
            }).ToList();
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
        public IActionResult EditCity(int cityid)
        {
           var CityData = _context.Cities.Where(x => x.ID == cityid).FirstOrDefault();
            if(CityData != null)
            {
                ViewBag.CountryCode = _context.Countries.Select(a => new SelectListItem
                {
                    Text = a.Code,
                    Value = a.Code
                }).ToList();
                TempData["CityID"] = cityid;
                TempData.Keep();
                return View(CityData);
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditCity(CityModel city)
        {
            int cityID = (int)TempData["CityID"];
            var CityData = _context.Cities.Where(x => x.ID == cityID).FirstOrDefault();

            if(CityData != null)
            {
                CityData.Name = city.Name;
                CityData.CountryCode = city.CountryCode;
                CityData.Population = city.Population;
                _context.Entry(CityData).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Cities");
        }

        public IActionResult DeleteCity(int cityid)
        {
            if(cityid > 0)
            {
                var citybyid = _context.Cities.Where(x => x.ID == cityid).FirstOrDefault();
                if(citybyid != null)
                {
                    _context.Entry(citybyid).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Cities");
        }

    }
}
