using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models.Interfaces
{
    public interface ICityService
    {
        public List<CityModel> GetAllCities();
        public CityModel GetCityById(int id);
        public CityModel GetCityByName(string name);
        public void DeleteCityById(int id);
        public void CreateCity(CreateCityViewModel vm);
    }
}
