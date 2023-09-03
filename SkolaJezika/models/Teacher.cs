using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.models
{
    public class Teacher : User, INotifyPropertyChanged
    {
        private School school;
        private List<Language> languages;
        private List<Class> classes;
        public Teacher()
        {
           this.classes = new List<Class>();
        }

        public Teacher(string firstName, string lastName, string jmbg, string email, string password, EUserType userType, EGender gender, Address address, bool active, School school, List<Language> languages, List<Class> classes) : base(firstName, lastName, jmbg, email, password, userType, gender, active, address)
        {
            this.school = school;
            this.languages = languages;
            this.classes = classes;
        }

        public School School { get => school; set { school = value; OnPropertyChanged("school"); } }
        public List<Language> Teachinglanguagess { get => languages; set { languages = value; OnPropertyChanged("school"); } }
        public List<Class> Classes { get => classes; set { classes = value; OnPropertyChanged("school"); } }

        //

        public new event PropertyChangedEventHandler PropertyChanged;

        protected new void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        //
    }
}
