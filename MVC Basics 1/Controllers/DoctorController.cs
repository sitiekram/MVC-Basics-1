using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Patient()
        {
            ViewBag.Message = "Enter your temperature in degree Celicus.";
            return View();
        }
        [HttpPost]
        public IActionResult Patient(string name,float temperature)
        {
            ViewBag.Message = PatientModel.CheckFever(name,temperature);
            return View();
        }
     
    }
}
