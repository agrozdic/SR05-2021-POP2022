using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.models
{
    public class Admin : User
    {
        public Admin() { }

        public Admin(string firstName, string lastName, string jmbg, string email, string password, EUserType userType, EGender gender, bool active, Address address) : base(firstName, lastName, jmbg, email, password, userType, gender, active, address)
        {
                
        }

        //
    }
}
