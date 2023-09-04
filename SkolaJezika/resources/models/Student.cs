using SkolaJezika.resources.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.resources.models
{
    public class Student : User, INotifyPropertyChanged
    {
        private List<Session> reservedSessions;

        public Student()
        {
            this.reservedSessions = new List<Session>();
        }

        public Student(string firstName, string lastName, string personalIdentityNumber, string email, string password, EUserType userType, EGender gender, Address address, bool active, List<Session> reservedClasses) : base(firstName, lastName, personalIdentityNumber, email, password, userType, gender, active, address)
        {
            this.reservedSessions = reservedClasses;
        }

        public List<Session> ReservedSessions { get => reservedSessions; set { reservedSessions = value; OnPropertyChanged("reservedSessions"); } }

        public new event PropertyChangedEventHandler PropertyChanged;

        protected new void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

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

        public override string ToString()
        {
            return this.firstName + " " + this.lastName;
        }
    }
}
