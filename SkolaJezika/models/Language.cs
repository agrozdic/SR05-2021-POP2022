using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR05-2021-POP2022.resources.models
{
    public class Language : INotifyPropertyChanged
    {
        private int id;
        private string languageName;
        private bool active;    
        public Language()
        {

        }

        public Language(int id, string languageName, bool active)
        {
            this.id = id;
            this.languageName = languageName;
            this.active = active;
        }

        public int Id { get => id; set { id = value; OnPropertyChanged("id"); } }

        public string LanguageName { get => languageName; set { languageName = value; OnPropertyChanged("languageName"); } }

        public bool Active { get => active; set { active = value; OnPropertyChanged("active"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public string FullLanguage
        {
            get
            {
                return $"{LanguageName}";
            }
        }
        
        protected void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public override string ToString()
        {
            return String.Format("{0}", LanguageName);
        }
    }
}
