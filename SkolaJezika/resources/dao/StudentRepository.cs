using SkolaJezika.resources.dao;
using SkolaJezika.resources.managers;
using SkolaJezika.utilities.file_related_utilities;
using SkolaJezika.resources.enums;
using SkolaJezika.resources.interfaces;
using SkolaJezika.resources.models;
using SkolaJezika.utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Net;

namespace SkolaJezika.resources.dao
{
    class StudentRepository
    {

        public void Read()
        {
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from Student";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student();
                    student.PersonalIdentityNumber = reader.GetString(0);
                    student.FirstName = reader.GetString(1);
                    student.LastName = reader.GetString(2);
                    student.Gender = (EGender)Enum.Parse(typeof(EGender), char.ToUpper(reader.GetString(3)[0]) + reader.GetString(3).Substring(1));
                    student.Address = AddressManager.GetInstance().GetAddressById(reader.GetInt32(4));
                    student.Email = reader.GetString(5);
                    student.Password = reader.GetString(6);
                    student.UserType = (EUserType)Enum.Parse(typeof(EUserType), char.ToUpper(reader.GetString(7)[0]) + reader.GetString(7).Substring(1));
                    student.Active = reader.GetBoolean(8);
                    StudentManager.GetInstance().AllStudents.Add(student);
                }
                conn.Close();
            }
        }

        public void Create(string firstName, string lastName, string personalIdentityNumber, string email, string password, EUserType userType, EGender gender, bool active, Address address, List<Session> reservedSessions)
        {
            Student student = new Student(firstName, lastName, personalIdentityNumber, email, password, userType, gender, address, active, reservedSessions);
            StudentManager.GetInstance().AllStudents.Add(student);
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into Student values(@jmbg ,@firstname, @lastname,@gender, @address, @email, @password, @usertype, @is_active)", conn))
                {
                    cmd.Parameters.AddWithValue("@jmbg", personalIdentityNumber);
                    cmd.Parameters.AddWithValue("@firstname", firstName);
                    cmd.Parameters.AddWithValue("@lastname", lastName);
                    cmd.Parameters.AddWithValue("@gender", gender.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@address", address.Id);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@usertype", userType.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@is_active", 1);
                    cmd.ExecuteNonQuery();
                }


                conn.Close();
            }
        }

        public void Update(string firstName, string lastName, string personalIdentityNumber, string email, string password, EUserType userType, EGender gender, bool active, Address address, List<Session> reservedSessions)
        {
            Student student = StudentManager.GetInstance().GetStudentByIdentityNumber(personalIdentityNumber);
            student.FirstName = firstName;
            student.LastName = lastName;
            student.Email = email;
            student.Password = password;
            student.UserType = userType;
            student.Gender = gender;
            student.Address = address;
            student.Active = active;
            student.ReservedSessions = reservedSessions;
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Student set  firstname=@firstname, lastname=@lastname, gender=@gender, address=@address, email=@email, password=@password where jmbg=@jmbg", conn))
                {
                    cmd.Parameters.AddWithValue("@jmbg", personalIdentityNumber);
                    cmd.Parameters.AddWithValue("@firstname", firstName);
                    cmd.Parameters.AddWithValue("@lastname", lastName);
                    cmd.Parameters.AddWithValue("@gender", gender.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@address", address.Id);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(string personalIdentityNumber)
        {
            Student student = StudentManager.GetInstance().GetStudentByIdentityNumber(personalIdentityNumber);
            student.Active = false;
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Student set  is_active=0 where jmbg=@jmbg", conn))
                {
                    cmd.Parameters.AddWithValue("@jmbg", personalIdentityNumber);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
