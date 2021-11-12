using Microsoft.AspNetCore.Http;
using MVC_Basics_1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class GuessModel
    {
        private HomeController aController;
        private Random rnd;
        public int GuessedNumber { get; set; }
        public int RandomNumber { get; set; }
       
        public GuessModel(HomeController aController)
        {
             this.aController = aController;
             rnd = new Random();
        }
        public void SetRandomNumber()
        {
            if (aController != null)
            {
                aController.HttpContext.Session.SetInt32("Random Number", rnd.Next(1, 101));
            }
        }
        public void GetRandomNumber()
        {
            if (aController != null)
            {
                RandomNumber= aController.HttpContext.Session.GetInt32("Random Number") ?? 1;
            }
            else 
            {
                RandomNumber = 1;
            }
        }

        public  string GuessNumber(int guessedNumber)
        {
            string message="";
            if (RandomNumber < guessedNumber)
            {
                message = "Your guess is too high";
            }
            else if (RandomNumber > guessedNumber)
            {
                message = "Your guess is too low";
            }
            else
            {
                message = "Congratulation. You have guessed the word correct.The number is" + guessedNumber;
            }
            return message; 
        }
    }
}
