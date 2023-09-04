using SkolaJezika.resources.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.resources.models
{
    public class Admin : User
    {
        public Admin() { }
        public Admin(string firstName, string lastName, string personalIdentityNumber, string email, string password, EUserType userType, EGender gender, bool active, Address address) : base(firstName, lastName, personalIdentityNumber, email, password, userType, gender, active, address)
        {
                
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
    }
}
