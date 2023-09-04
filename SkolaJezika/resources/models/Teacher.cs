using SkolaJezika.resources.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.resources.models
{
    public class Teacher : User, INotifyPropertyChanged
    {
        private School workingSchool;
        private List<Language> teachingLanguages;
        private List<Session> sessions;
        public Teacher()
        {
           this.sessions = new List<Session>();
        }

        public Teacher(string firstName, string lastName, string personalIdentityNumber, string email, string password, EUserType userType, EGender gender, Address address, bool active, School workingSchool, List<Language> teachingLanguages, List<Session> sessions) : base(firstName, lastName, personalIdentityNumber, email, password, userType, gender, active, address)
        {
            this.workingSchool = workingSchool;
            this.teachingLanguages = teachingLanguages;
            this.sessions = sessions;
        }

        public School WorkingSchool { get => workingSchool; set { workingSchool = value; OnPropertyChanged("workingSchool"); } }
        public List<Language> TeachingLanguages { get => teachingLanguages; set { teachingLanguages = value; OnPropertyChanged("workingSchool"); } }
        public List<Session> Sessions { get => sessions; set { sessions = value; OnPropertyChanged("workingSchool"); } }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("firstName"); }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("lastName"); }
        }
        public string PersonalIdentityNumber
        {
            get { return personalIdentityNumber; }
            set { personalIdentityNumber = value; OnPropertyChanged("personalIdentityNumber"); }
        }
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("email"); }
        }
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("password"); }
        }
        public EUserType UserType
        {
            get { return userType; }
            set { userType = value; OnPropertyChanged("userType"); }
        }
        public EGender Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged("gender"); }
        }
        public Address Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("address"); }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged("active"); }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        protected new void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public override string ToString()
        {
            return this.firstName + " " + this.lastName;
        }
    }
}
