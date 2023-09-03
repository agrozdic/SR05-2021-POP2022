using SkolaJezika.dao;
using SkolaJezika.managers;
using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkolaJezika.services
{
    class AdminService
    {
        AdminRepository repository;

        public AdminService()
        {
            repository = new AdminRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
        }

        private void FillModelManager()
        {
            repository.Read();
        }

        public Admin FindByIDAndPassword(string id, string password)
        {
            Admin a = AdminManager.GetInstance().AllAdmins.ToList().Find(admin => admin.Jmbg == id && admin.Password == password);
            return a;
        }
    }
}
