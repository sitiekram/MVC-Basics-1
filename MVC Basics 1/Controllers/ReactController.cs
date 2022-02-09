using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;
using MVC_Basics_1.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

namespace MVC_Basics_1.Controllers
{
    public class ReactController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPersonService _personService;
        private readonly ICityService _cityService;
        private readonly ILanguageService _languageService;

        public ReactController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public ReactController(IPersonService personService, ICityService cityService, ILanguageService languageService)
        //{
        //    _personService = personService;
        //    _cityService = cityService;
        //    _languageService = languageService;
        //}

        // GET: /<controller>/

        //public IActionResult Index()
        //{

        //    return View();
        //}

        //[HttpGet]
        //[Route("/React/People")]
        //public IActionResult GetPeople()
        //{
        //    var people = _personService.GetAllPeople();

        //    var dto = new List<PersonDTO>();
        //    foreach (var p in people)
        //    {
        //        dto.Add(
        //            new PersonDTO
        //            {
        //                Id = p.PersonId,
        //                Name = p.FullName,
        //                CityName = p.City.Name,
        //                CountryName = p.City.Country.Name,
        //                Phone = p.PhoneNumber,
        //                Email = p.Email,
        //                Languages = new List<string>()

        //            });
        //    }

        //    return Ok(JsonConvert.SerializeObject(dto));

        //}

        //[HttpGet]
        //[Route("/React/People/{id:int}")]
        //public IActionResult GetPersonById(int id)
        //{
        //    PeopleModel person = _personService.GetPersonById(id);
        //    var languages = new List<string>();
        //    foreach (var pl in person.PeopleLanguages)
        //    {
        //        languages.Add(pl.Language.Name);
        //    }
        //    var dto = new PersonDTO
        //    {
        //        Id = person.PersonId,
        //        Name = person.FullName,
        //        Phone = person.PhoneNumber,
        //        CityName = person.City.Name,
        //        CountryName = person.City.Country.Name,
        //        Email = person.Email,
        //        Languages = languages

        //    };
        //    return Ok(JsonConvert.SerializeObject(dto));
        //}


        //[HttpPost]
        //[Route("/React/People/Create")]
        //public IActionResult CreatePerson([FromBody] CreatePersonViewModel pVm)
        //{
        //    _personService.CreatePerson(pVm);

        //    return Ok();
        //}

        //[HttpDelete]
        //[Route("/React/People/{id:int}")]
        //public IActionResult DeletePerson(int id)
        //{
        //    try
        //    {
        //        _personService.DeletePersonById(id);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpGet]
        //[Route("/React/Cities")]
        //public IActionResult GetCities()
        //{
        //    var cities = _cityService.GetAllCities();

        //    var dto = new List<CityDTO>();
        //    foreach (var c in cities)
        //    {
        //        dto.Add(
        //            new CityDTO
        //            {
        //                Id = c.ID,
        //                CityName = c.Name,
        //                CountryName = c.Country.Name,
        //                CountryId = c.Country.Code

        //            });
        //    }

        //    return Ok(JsonConvert.SerializeObject(dto));

        //}

        //[HttpGet]
        //[Route("/React/Languages")]
        //public IActionResult GetLanguages()
        //{
        //    var languages = _languageService.GetAllLanguages();

        //    var dto = new List<LanguageDTO>();
        //    foreach (var l in languages)
        //    {
        //        dto.Add(
        //            new LanguageDTO
        //            {
        //                Id = l.LanguageID,
        //                Language = l.Name

        //            });
        //    }

        //    return Ok(JsonConvert.SerializeObject(dto));

        //}
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
        [Route("/React/DeletePerson")]
        public IActionResult DeletePerson(int id)
        {
            _context.People.Remove(_context.People.Find(id));
            _context.SaveChanges();

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
                //genders = Enum.GetNames(typeof(Gender)),
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
                    Email = person.Email
                });
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }
    }

    //[HttpGet]
    //[Route("api/React/People")]
    //public IActionResult People()
    //{
    //   return Json(_context.People);
    //}
    //public IActionResult People()
    //{
    //    List<PeopleModel> ListOfPeople = _context.People.ToList();
    //    return Json(new { values = ListOfPeople }, JsonRequestBehavior.AllowGet);
    //}

    //[HttpGet]
    //public IActionResult GetAllPersons()
    //{
    //    var peopleWithLangList = _context.People.Include(p => p.City).Include(pl => pl.PeopleLanguages)
    //        .ThenInclude(l => l.Language).ToList();
    //    var reactPeopleVMList = new List<ReactPeopleViewModel>();
    //    foreach (var item in peopleWithLangList)
    //    {
    //        var personLanguages = item.PeopleLanguages.Select(p => p.Language).ToList();
    //        var reactLanguageVMList = new List<ReactLanguageViewModel>();
    //        foreach (var lang in personLanguages)
    //        {
    //            reactLanguageVMList.Add(new ReactLanguageViewModel(lang.LanguageID, lang.Name));
    //        }
    //        reactPeopleVMList.Add(new ReactPeopleViewModel(item.PersonId, item.FullName,item.City.Name, reactLanguageVMList));
    //    }

    //    var citiesList = _context.Cities.ToList();
    //    var reactCityVMList = new List<ReactCityViewModel>();
    //    foreach (var item in citiesList)
    //    {
    //        reactCityVMList.Add(new ReactCityViewModel(item.ID, item.Name));
    //    }

    //    ReactViewModel reactVM = new ReactViewModel();
    //    reactVM.ReactPeopleVMList = reactPeopleVMList;
    //    reactVM.CitiesList = reactCityVMList;

    //    return Json(reactVM);
    //}

}

