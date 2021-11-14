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
        private static int counter = 0;
       
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
                counter = 0;
            }
        }

        public  string GuessNumber(int guessedNumber)
        {
            string message;
            if (guessedNumber < 1 || guessedNumber > 100)
            {
                message = "Please enter a number between 1 and 100.";
            }
            else
            {
                if (RandomNumber < guessedNumber)
                {
                    ++counter;
                    message = "Your guess is too high  \nGuess counter :- "+counter;
                }
                else if (RandomNumber > guessedNumber)
                {
                    ++counter;
                    message = $"Your guess is too low   \nGuess counter :- {counter}";
                }
                else
                {
                    ++counter;
                    message = $"Congratulation. You have guessed the word correct after {counter} tries.The number is {guessedNumber}.\nEnter a number and click 'Submit' button inorder to guess the new number";
                    this.SetRandomNumber();
                    counter = 0;
                }
            }
            return message; 
        }
    }
}
