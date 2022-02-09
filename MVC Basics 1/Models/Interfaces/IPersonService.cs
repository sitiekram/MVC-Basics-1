using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models.Interfaces
{
    public interface IPersonService
    {
        public List<PeopleModel> GetAllPeople();
        public PeopleModel GetPersonById(int id);
        public PeopleModel GetPersonByName(string name);
        public void DeletePersonById(int id);
        public void CreatePerson(CreatePersonViewModel vm);

    }
}
