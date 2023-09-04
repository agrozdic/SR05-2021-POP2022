using SkolaJezika.resources.dao;
using SkolaJezika.resources.managers;
using SkolaJezika.resources.models;
using SkolaJezika.utilities.exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.resources.services
{
    class LanguageService
    {
        LanguageRepository repository = null;

        public LanguageService()
        {
            repository = new LanguageRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
        }

        private void FillModelManager()
        {
            repository.Read();
        }
        

        public ObservableCollection<Language> GetAllLanguages()
        {
            try
            {
                ObservableCollection<Language> languages = new ObservableCollection<Language>(LanguageManager.GetInstance().AllLanguages.Where(ad => ad.Active).ToList());
                return languages;
            }
            catch (LanguageNotFoundException exception)
            {
                return new ObservableCollection<Language>();
            }
        }
        public void CreateLanguage( string languageName)
        {
            repository.Create(languageName);
        }

        public void UpdateLanguage(int id, string languageName)
        {
            repository.Update(id, languageName);
        }

        public void DeleteLanguage(int id)
        {
            repository.Delete(id);
        }
    }
}
