using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class PatientModel
    {
        public string Name { get; set; }
        public int Temperature { get; set; }
        
       public static string CheckFever(string name,float temperature)
        {
            string message;
            if (temperature >= 37.5)
            {
                message = name + " " + "You have Fever! You need to see your doctor!";
            }
            else if (temperature <= 37 && temperature >= 35)
            {
                message = name + " " + "Your temperature is Normal!";
            }
            else if (temperature <= 34.5 && temperature >= 32)
            {
                message = name + " " + "Your temperature is below average, You have Mild Hypothermia!";
            }
            else if (temperature <= 31 && temperature >= 28)
            {
                message = name + " " + "Your temperature is below average, You have moderate Hypothermia!";
            }
            else if (temperature <= 27)
            {
                message = name + " " + "You have severe Hypothermia! You need to see your doctor!";
            }
            else
            {
                message = name + " " + "Re-enter your temperature!";
            }
            return message;
        }

    }
}
