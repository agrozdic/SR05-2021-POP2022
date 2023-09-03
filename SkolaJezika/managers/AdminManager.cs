using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.managers
{
    class AdminManager
    {
        private static AdminManager instance;
        private ObservableCollection<Admin> allAdmins = new ObservableCollection<Admin>();

        public ObservableCollection<Admin> AllAdmins { get => allAdmins; set => allAdmins = value; }

        public AdminManager() { }

        public static AdminManager GetInstance()
        {
            if (instance == null) instance = new AdminManager();
            return instance;
        }
    }
}
