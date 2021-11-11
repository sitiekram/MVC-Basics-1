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
        
        public static string CheckFever(float temperature)
        {
            string message;
            if(temperature >= 38)
            {
                message = "You have a fever";
            }
            else
            {
                message = "You didn't have a fever";
            }
            return message;
        }

    }
}
