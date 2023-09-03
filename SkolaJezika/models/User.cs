using SR38_2021_POP2022.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR05=2021=POP20222.models
{
    public abstract class User : INotifyPropertyChanged
    {


        private string firstName;
        private string lastName;
        private string jmbg;
        private string email;
        private string password;
        private EUserType userType;
        private EGender gender;
        private Address address;
        private bool active;

        private User() { }

        private User(string firstName, string lastName, string jmbg, string email, string password, EUserType userType, EGender gender, bool active, Address address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.jmbg = jmbg;
            this.email = email;
            this.password = password;
            this.userType = userType;
            this.gender = gender;
            this.active = active;
            this.address = address;
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
        public string jmbg
        {
            get { return jmbg; }
            set { jmbg = value; OnPropertyChanged("jmbg"); }
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String name)
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
