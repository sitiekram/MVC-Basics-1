using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class GuessController : Controller
    {
        public IActionResult Index()
        {
            GuessModel gs = new GuessModel(this);
            gs.SetRandomNumber();
            return View();
        }
        [HttpPost]
        public IActionResult Index(int number)
        {
            GuessModel gs = new GuessModel(this);
            gs.GetRandomNumber();
            ViewBag.Message = gs.GuessNumber(number);
            return View();
        }
    }
}
