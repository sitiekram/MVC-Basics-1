//using Microsoft.EntityFrameworkCore;
//using MVC_Basics_1.Data;
//using MVC_Basics_1.Models.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MVC_Basics_1.Models.Services
//{
//    public class CityService : ICityService
//    {
//        private readonly ApplicationDbContext _context;
//        public CityService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public List<CityModel> GetAllCities()
//        {
//            return _context.Cities.Include(c => c.Country).ToList();
//        }
//        public CityModel GetCityById(int id)
//        {
//            return _context.Cities.Find(id);
//        }
//        public CityModel GetCityByName(string name)
//        {
//            return _context.Cities.First(n => n.Name.Equals(name));
//        }
//        public void DeleteCityById(int id)
//        {
//            var city = GetCityById(id);
//            _context.Cities.Remove(city);
//            _context.SaveChanges();
//        }
//        public void CreateCity(CreateCityViewModel vm)
//        {
//            _context.Cities.Add(
//                new CityModel { Name = vm.Name, Country = _context.Countries.Find(vm.CountryCode) });
//            _context.SaveChanges();

//        }
//    }
//}
