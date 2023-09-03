using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.models
{
    public class Student : User, INotifyPropertyChanged
    {
        private List<Classes> reservedClasses;

        public Student()
        {
            this.reservedClasses = new List<Classes>();
        }

        public Student(string firstName, string lastName, string jmbg, string email, string password, EUserType userType, EGender gender, Address address, bool active, List<Classes> reservedClasses) : base(firstName, lastName, jmbg, email, password, userType, gender, active, address)
        {
            this.reservedClasses = reservedClasses;
        }

        public List<Classes> ReservedClasses { get => reservedClasses; set { reservedClasses = value; OnPropertyChanged("reservedClasses"); } }

        public new event PropertyChangedEventHandler PropertyChanged;

        protected new void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        //

        //
    }
}
