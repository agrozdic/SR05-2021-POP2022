using SR05-2021-POP2022.exceptions;
using SR05-2021-POP2022.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SR05-2021-POP2022.managers
{
    class ClassManager
    {
        private static ClassManager instance;
        private ObservableCollection<Class> allClasses
            = new ObservableCollection<Class>();

        public ObservableCollection<Class> AllClasses { get => allClasses; set => allClasses = value; }

        private ClassManager() { }

        public static ClassManager GetInstance()
        {
            if (instance == null) instance = new ClassManager();
            return instance;
        }

        public Class GetClassById(int id)
        {

            Class foundClass = allClasses.ToList().Find(x => x.Id == id);
            if (foundClass == null)
            {
                throw new ClassNotFoundException("Cas nije pronadjen.");
            }
            return foundClass;
        }

        public ObservableCollection<Class> GetClassesBasedByID(string[] splittedIndexes)
        {
            ObservableCollection<Class> classes = new ObservableCollection<Class>();
            foreach(string splittedIndex in splittedIndexes)
            {
                if (splittedIndex != "-1") classes.Add(GetClassById(int.Parse(splittedIndex)));
            }
            return classes;
        }

        public ObservableCollection<Class> GetClassesBasedByID(int[] splittedIndexes)
        {
            ObservableCollection<Class> classes = new ObservableCollection<Class>();
            foreach (int splittedIndex in splittedIndexes)
            {
                classes.Add(GetClassById(splittedIndex));
            }
            return classes;
        }
    }
}
