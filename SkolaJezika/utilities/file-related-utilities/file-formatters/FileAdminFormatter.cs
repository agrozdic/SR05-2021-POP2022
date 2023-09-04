using SkolaJezika.resources.enums;
using SkolaJezika.resources.managers;
using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.utilities.file_related_utilities.file_formatters
{
    class FileAdminFormatter
    {

        public static Admin createAdminFromFile(string[] splittedLine)
        {
            Admin admin = new Admin();
            admin.PersonalIdentityNumber = splittedLine[0];
            admin.FirstName = splittedLine[1];
            admin.LastName = splittedLine[2];
            admin.Email = splittedLine[3];
            admin.Password = splittedLine[4];
            admin.UserType = (EUserType)int.Parse(splittedLine[5]);
            admin.Gender = (EGender)int.Parse(splittedLine[6]);
            admin.Address = AddressManager.GetInstance().GetAddressById(int.Parse(splittedLine[7]));
            admin.Active = bool.Parse(splittedLine[8]);
            return admin;
        }

        public static string CreateStringFormatForFile(Admin admin)
        {
            return String.Format(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", admin.PersonalIdentityNumber, admin.FirstName, admin.LastName, admin.Email, admin.Password, (int)admin.UserType, (int)admin.Gender, admin.Address.Id, admin.Active));
        }
    }
}
