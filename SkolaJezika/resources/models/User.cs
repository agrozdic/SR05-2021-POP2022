using SkolaJezika.resources.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.resources.models
{
    public abstract class User : INotifyPropertyChanged
    {


        protected string firstName;
        protected string lastName;
        protected string personalIdentityNumber;
        protected string email;
        protected string password;
        protected EUserType userType;
        protected EGender gender;
        protected bool active;
        protected Address address;

        protected User() { }

        protected User(string firstName, string lastName, string personalIdentityNumber, string email, string password, EUserType userType, EGender gender, bool active, Address address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.personalIdentityNumber = personalIdentityNumber;
            this.email = email;
            this.password = password;
            this.userType = userType;
            this.gender = gender;
            this.active = active;
            this.address = address;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
