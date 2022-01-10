using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Basics_1.Data;
using MVC_Basics_1.Models;
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

        public ReactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult People()
        //{
        //    List<PeopleModel> ListOfPeople = _context.People.ToList();
        //    return Json(new { values = ListOfPeople }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        //}
    
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            var peopleWithLangList = _context.People.Include(p => p.City).Include(pl => pl.PeopleLanguages)
                .ThenInclude(l => l.Language).ToList();
            var reactPeopleVMList = new List<ReactPeopleViewModel>();
            foreach (var item in peopleWithLangList)
            {
                var personLanguages = item.PeopleLanguages.Select(p => p.Language).ToList();
                var reactLanguageVMList = new List<ReactLanguageViewModel>();
                foreach (var lang in personLanguages)
                {
                    reactLanguageVMList.Add(new ReactLanguageViewModel(lang.LanguageID, lang.Name));
                }
                reactPeopleVMList.Add(new ReactPeopleViewModel(item.PersonId, item.FullName,item.City.Name, reactLanguageVMList));
            }

            var citiesList = _context.Cities.ToList();
            var reactCityVMList = new List<ReactCityViewModel>();
            foreach (var item in citiesList)
            {
                reactCityVMList.Add(new ReactCityViewModel(item.ID, item.Name));
            }

            ReactViewModel reactVM = new ReactViewModel();
            reactVM.ReactPeopleVMList = reactPeopleVMList;
            reactVM.CitiesList = reactCityVMList;

            return Json(reactVM);
        }
    }
}
