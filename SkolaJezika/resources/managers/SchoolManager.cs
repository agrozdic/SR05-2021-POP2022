using SkolaJezika.utilities.exceptions;
using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SkolaJezika.resources.managers
{
    class SchoolManager
    {
        private static SchoolManager instance;
        private ObservableCollection<School> allSchools = new ObservableCollection<School>();
        
        public ObservableCollection<School> AllSchools { get => allSchools; set => allSchools = value; }

        private SchoolManager() { }

        public static SchoolManager GetInstance()
        {
            if (instance == null) instance = new SchoolManager();
            return instance;
        }

        public School GetSchoolById(int id)
        {
            
            School school = allSchools.ToList().Find(x => x.Id == id);
            if (school == null)
            {
                throw new SchoolNotFoundException("Skola ne postoji.");
            }
            return school;
        }

        public School GetSchoolByName(string name)
        {

            School school = allSchools.ToList().Find(x => x.Name == name);
            if (school == null)
            {
                throw new SchoolNotFoundException("Skola ne postoji.");
            }
            return school;
        }

        public ObservableCollection<School> GetSchoolByLanguage(string languageName)
        {
            ObservableCollection<School> foundSchools = new ObservableCollection<School>();

            allSchools.ToList().ForEach(school =>
            {
                if (school.AllLanguages.ToList().Exists(x => x.LanguageName == languageName))
                {
                    foundSchools.Add(school);
                }
            });

            return foundSchools;
        }

    }
}
