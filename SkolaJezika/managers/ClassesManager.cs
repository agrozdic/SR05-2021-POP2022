//using SkolaJezika.exceptions;
using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SkolaJezika.managers
{
    class ClassesManager
    {
        private static ClassesManager instance;
        private ObservableCollection<Classes> allClasses
            = new ObservableCollection<Classes>();

        public ObservableCollection<Classes> AllClasses { get => allClasses; set => allClasses = value; }

        private ClassesManager() { }

        public static ClassesManager GetInstance()
        {
            if (instance == null) instance = new ClassesManager();
            return instance;
        }

        public Classes GetClassesById(int id)
        {

            Classes foundClasses = allClasses.ToList().Find(x => x.Id == id);
            if (foundClasses == null)
            {
                throw new ClassesNotFoundException("Cas nije pronadjen.");
            }
            return foundClasses;
        }

        public ObservableCollection<Classes> GetClassesBasedByID(string[] splittedIndexes)
        {
            ObservableCollection<Classes> classes = new ObservableCollection<Classes>();
            foreach(string splittedIndex in splittedIndexes)
            {
                if (splittedIndex != "-1") classes.Add(GetClassesById(int.Parse(splittedIndex)));
            }
            return classes;
        }

        public ObservableCollection<Classes> GetClassesBasedByID(int[] splittedIndexes)
        {
            ObservableCollection<Classes> classes = new ObservableCollection<Classes>();
            foreach (int splittedIndex in splittedIndexes)
            {
                classes.Add(GetClassesById(splittedIndex));
            }
            return classes;
        }
    }
}
