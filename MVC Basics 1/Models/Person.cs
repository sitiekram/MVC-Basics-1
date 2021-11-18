using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class Person
    {
        private readonly int _personId;
        public int PersonId { get { return _personId; } }
        public string FullName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Person(int _personId, string fullName, string city, string phoneNumber, string email)
        {
            this._personId = _personId;
            FullName = fullName;
            City = city;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
