using SkolaJezika.resources.enums;
using SkolaJezika.resources.managers;
using SkolaJezika.resources.models;
using SkolaJezika.utilities;
using SkolaJezika.utilities.file_related_utilities.file_formatters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.resources.dao
{
    class AdminRepository
    {

        public void Read()
        {

            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from Administrator where is_active = 1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Admin admin = new Admin();
                    admin.PersonalIdentityNumber = reader.GetString(0);
                    admin.FirstName = reader.GetString(1);
                    admin.LastName = reader.GetString(2);
                    admin.Gender = (EGender)Enum.Parse(typeof(EGender), reader.GetString(3));
                    admin.Address = AddressManager.GetInstance().GetAddressById(reader.GetInt32(4));
                    admin.Email = reader.GetString(5);
                    admin.Password = reader.GetString(6);
                    admin.UserType = (EUserType)Enum.Parse(typeof(EUserType), reader.GetString(7));
                    admin.Active = reader.GetBoolean(8);
                    AdminManager.GetInstance().AllAdmins.Add(admin);
                }

                conn.Close();
            }
        }
    }
}
