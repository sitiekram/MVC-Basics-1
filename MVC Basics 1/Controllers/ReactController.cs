using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    public class ReactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/React/People")]
        public IActionResult People()
        {
            return Json(_context.People.ToList());
        }

        [HttpGet]
        public IActionResult Person(int id)
        {
            var person = _context.People
                .Where(p => p.PersonId == id)
                .Include(p => p.City)
                .Include(p => p.City.Country)
                .Include(p => p.PeopleLanguages)
                .FirstOrDefault();

            if (person != null)
            {
                foreach (People_LanguageModel personLanguage in person.PeopleLanguages)
                {
                    personLanguage.Language = _context.Languages.Find(personLanguage.LanguageID);
                }

            }

            return Json(person);
        }

        [HttpDelete]
        public IActionResult DeletePerson(int id)
        {
            if (id > 0)
            {
                var personbyId = _context.People.Where(x => x.PersonId == id).FirstOrDefault();
                if (personbyId != null)
                {
                    _context.Entry(personbyId).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetCitiesInCountry(string id)
        {
            List<CityModel> cities = _context.Cities.Where(city => city.CountryCode == id).ToList();

            return Json(cities);
        }

        [HttpGet]
        public IActionResult GetFormData()
        {
            var data = new
            {
                countries = _context.Countries.ToList(),
                cities = _context.Cities.ToList()
            };

            return Json(data);
        }


        [HttpPut]
        public IActionResult CreatePerson(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(new PeopleModel()
                {
                    FullName = person.FullName,
                    CityID = person.CityID,
                    PhoneNumber = person.PhoneNumber,
                    Email = person.Email,
                });
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }
    }
}

