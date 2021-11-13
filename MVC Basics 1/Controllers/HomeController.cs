using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        public IActionResult Guess()
        {
            GuessModel gs = new GuessModel(this);
            gs.SetRandomNumber();
            return View();
        }
        [HttpPost]
        public IActionResult Guess(int number)
        { 
            GuessModel gs = new GuessModel(this);
            gs.GetRandomNumber();
            ViewBag.Message = gs.GuessNumber(number);
            return View();
        }
    }
}
