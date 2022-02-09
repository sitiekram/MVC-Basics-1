//using MVC_Basics_1.Data;
//using MVC_Basics_1.Models.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MVC_Basics_1.Models.Services
//{
//    public class LanguageService : ILanguageService
//    {
//        private readonly ApplicationDbContext _context;
//        public LanguageService(ApplicationDbContext context)
//        { 
//            _context = context;
//        }
//        public List<LanguageModel> GetAllLanguages()
//        {
//            return _context.Languages.ToList();
//        }
//        public LanguageModel GetLanguageById(int id)
//        {
//            return _context.Languages.Find(id);
//        }
//        public LanguageModel GetLanguageByName(string name)
//        {
//            return _context.Languages.First(n => n.Name.Equals(name));
//        }
//        public void DeleteLanguageById(int id)
//        {
//            var l = GetLanguageById(id);
//            _context.Languages.Remove(l);
//            _context.SaveChanges();
//        }
//        public void CreateLanguage(CreateLanguageViewModel vm)
//        {
//            _context.Languages.Add(
//               new LanguageModel { Name = vm.Name });
//            _context.SaveChanges();
//        }
//    }
//}
