using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models
{
    public class PeopleMemory
    {
        private static List<Person> personList = new List<Person>();
        private static int _idCounter;

        public void SeedPeople()
        {
            PeopleMemory peoplememory = new PeopleMemory();
            peoplememory.Create("Ekram Ahmedin", "Trollhättan", "0723233234", "esdf3@gmail.com");
            peoplememory.Create("Eve Ulf", "Göteborg", "0734567453", "wsdfgjjgv@gmail.com");
            peoplememory.Create("Marwan Ali", "Vänersborg", "0789435634", "s4fdg@hotmail.com");
            peoplememory.Create("Andersson Tomas", "Göteborg", "+46792055765", "rahwaali2@gmail.com");
            peoplememory.Create("Sofia Abdullah", "Vänersborg", "+46792511963", "bubt78s@hotmail.com");
            peoplememory.Create("Rahwa Suliman", "Stockholm", "0793498567", "reregs5@gmail.com");
        }
        public Person Create(string fullName, string city, string phoneNumber, string email)
        {
            Person newPerson = new Person(_idCounter, fullName, city, phoneNumber, email);
            _idCounter++;
            personList.Add(newPerson);
            return newPerson;
        }
        public bool Delete(Person person)
        {
            bool status = personList.Remove(person);
            return status;
        }
        public List<Person> Read()
        {
            return personList;
        }

        public Person Read(int id)
        {
            Person targetPerson = personList.Find(p => p.PersonId == id);
            return targetPerson;
        }
    }
}
