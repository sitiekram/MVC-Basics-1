﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Models.Interfaces
{
    public interface ILanguageService
    {
        public List<LanguageModel> GetAllLanguages();
        public LanguageModel GetLanguageById(int id);
        public LanguageModel GetLanguageByName(string name);
        public void DeleteLanguageById(int id);
        public void CreateLanguage(CreateLanguageViewModel vm);
    }
}
