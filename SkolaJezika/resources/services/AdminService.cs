using SkolaJezika.resources.dao;
using SkolaJezika.resources.managers;
using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkolaJezika.resources.services
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

        public Admin FindByPersonalIDAndPassword(string personalID, string password)
        {
            Admin a = AdminManager.GetInstance().AllAdmins.ToList().Find(admin => admin.PersonalIdentityNumber == personalID && admin.Password == password);
            return a;
        }
    }
}
