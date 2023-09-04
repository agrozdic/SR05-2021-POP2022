using SkolaJezika.resources.managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.utilities
{
    class IDGenerator
    {
        public static int GenerateAddressID()
        {
            int newID = AddressManager.GetInstance().AllAddresses.Max(address => address.Id) + 1;
            return newID;
        }

        public static int GenerateSessionID()
        {
            int newID = SessionManager.GetInstance().AllSessions.Max(session => session.Id) + 1;
            return newID;
        }

        public static int GenerateSchoolID()
        {
            int newID = SchoolManager.GetInstance().AllSchools.Max(school => school.Id) + 1;
            return newID;
        }

        public static int GenerateLanguageID()
        {
            int newID = LanguageManager.GetInstance().AllLanguages.Max(language => language.Id) + 1;
            return newID;
        }
    }
}
