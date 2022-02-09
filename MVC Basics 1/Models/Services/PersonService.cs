//using Microsoft.EntityFrameworkCore;
//using MVC_Basics_1.Data;
//using MVC_Basics_1.Models.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MVC_Basics_1.Models.Services
//{
//    public class PersonService : IPersonService
//    {
//        private readonly ApplicationDbContext _context;

//        public PersonService(ApplicationDbContext context)
//        {
//            _context = context;

//        }
//        public List<PeopleModel> GetAllPeople()
//        {
//            return _context.People.Include(p => p.City)
//                                    .ThenInclude(c => c.Country)
//                                    .Include(l => l.PeopleLanguages)
//                                    .ToList();
//        }
//        public PeopleModel GetPersonById(int id)
//        {
//            var person = _context.People.Find(id);
//            var personLanguages = _context.PeopleLanguages
//                                    .Include(pl => pl.Language)
//                                    .Where(p => p.PersonId == id);
//            person.City = _context.Cities.Find(person.City.CountryCode);
//            person.PeopleLanguages = _context.PeopleLanguages.ToList();
//            return person;
//        }
//        public PeopleModel GetPersonByName(string name)
//        {
//            return _context.People.AsQueryable().First(n => n.FullName.Equals(name));
//        }

//        public void DeletePersonById(int id)
//        {
//            var person = GetPersonById(id);
//            if (person is null) return;
//            _context.People.Remove(person);
//            _context.SaveChanges();
//        }

//        public void CreatePerson(CreatePersonViewModel vm)
//        {
//            var newPerson = new PeopleModel
//            {
//                FullName = vm.FullName,
//                City = _context.Cities.Find(vm.City),
//                PhoneNumber = vm.PhoneNumber,
//                Email = vm.Email
//            };
//            _context.People.Add(newPerson);
//            _context.SaveChanges();

//            foreach (var languageId in vm.Languages)
//            {
//                _context.PeopleLanguages.Add(new People_LanguageModel
//                {
//                    PersonId = newPerson.PersonId,
//                    LanguageID = languageId

//                });
//            }
//            _context.SaveChanges();

//        }
//    }
//}
