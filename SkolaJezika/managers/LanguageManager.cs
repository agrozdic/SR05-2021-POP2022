//using SkolaJezika.exceptions;
using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SkolaJezika.managers
{
    class LanguageManager : INotifyPropertyChanged
    {
        private static LanguageManager instance;
        private ObservableCollection<Language> allLanguages = new ObservableCollection<Language>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Language> AllLanguages { get => allLanguages; set { allLanguages = value; OnPropertyChanged("allLanguages"); } }

        private LanguageManager() { }
        public static LanguageManager GetInstance()
        {
            if (instance == null) instance = new LanguageManager();
            return instance;
        }

        public Language GetLanguageById(int id)
        {

            Language language = allLanguages.ToList().Find(x => x.Id == id);
            if(language == null)
            {
                //throw new LanguageNotFoundException("Jezik nije pronadjen.");
            }
            return language;
        }

        public Language GetLanguageByName(string name)
        {

            Language language = allLanguages.ToList().Find(x => x.LanguageName == 
                name);
            if (language == null)
            {
                //throw new LanguageNotFoundException("Jezik nije pronadjen.");
            }
            return language;
        }

        public ObservableCollection<Language> GetLanguagesBasedById(string[] splittedIndexes)
        {
            ObservableCollection<Language> createdLanguages = new ObservableCollection<Language>();
            foreach (string line in splittedIndexes)
            {
                createdLanguages.Add(GetLanguageById(int.Parse(line)));
            }
            return createdLanguages;
        }

        public List<Language> GetLanguagesBasedById(int[] splittedIndexes)
        {
            List<Language> createdLanguages = new List<Language>();
            foreach (int index in splittedIndexes)
            {
                createdLanguages.Add(GetLanguageById(index));
            }
            return createdLanguages;
        }

        protected void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
