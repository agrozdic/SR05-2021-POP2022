using SR05-2021-POP2022.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR05-2021-POP2022.models
{
    public class Teacher : User, INotifyPropertyChanged
    {
        private School school;
        private List<languages> languages;
        private List<Session> classes;
        public Teacher()
        {
           this.classes = new List<Session>();
        }

        public Teacher(string firstName, string lastName, string jmbg, string email, string password, EUserType userType, EGender gender, Address address, bool active, School school, List<languages> languages, List<Session> classes) : base(firstName, lastName, jmbg, email, password, userType, gender, active, address)
        {
            this.school = school;
            this.languages = languages;
            this.classes = classes;
        }

        public School school { get => school; set { school = value; OnPropertyChanged("school"); } }
        public List<languages> Teachinglanguagess { get => languages; set { languages = value; OnPropertyChanged("school"); } }
        public List<Session> classes { get => classes; set { classes = value; OnPropertyChanged("school"); } }

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
