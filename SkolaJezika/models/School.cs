using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.models
{
    public class School : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private Address address;
        private List<Language> allLanguages;
        private bool active;
        public School()
        {

        }

        public School(int id, string name, Address address, List<Language> allLanguages, bool active)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.allLanguages = allLanguages;
            this.active = active;
        }

        public int Id { get => id; set { id = value; OnPropertyChanged("id"); } }

        public string Name { get => name; set { name = value; OnPropertyChanged("name"); } }

        public Address Address { get => address; set { address = value; OnPropertyChanged("address"); } }

        public List<Language> AllLanguages { get => allLanguages; set { allLanguages = value; OnPropertyChanged("allLanguages"); } }
        
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
            return String.Format($"{this.Name}");
        }
    }
}
