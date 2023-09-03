using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.models
{
    public class Address : INotifyPropertyChanged
    {
        private int id;
        private string street;
        private int number;
        private string city;
        private string country;
        private bool active;

        public Address()
        {

        }


        public Address(int id, string street, int number, string city, string country, bool active)
        {
            this.id = id;
            this.street = street;
            this.number = number;
            this.city = city;
            this.country = country;
            this.active = active;
        }

        public int Id { get => id; set { id = value; OnPropertyChanged("id"); } }

        public string Street { get => street; set { street = value; OnPropertyChanged("street"); } }

        public int Number { get => number; set { number = value; OnPropertyChanged("number"); } }

        public string City { get => city; set { city = value; OnPropertyChanged("city"); } }
        
        public string Country { get => country; set { country = value; OnPropertyChanged("country"); } }

        public bool Active { get => active; set { active = value; OnPropertyChanged("active"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public override string ToString()
        {
            return ($"{street} {number} {city} {country}");
        }
    }
}
