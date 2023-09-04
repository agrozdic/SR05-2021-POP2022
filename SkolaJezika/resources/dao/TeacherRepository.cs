using SkolaJezika.resources.managers;
using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using SkolaJezika.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SkolaJezika.resources.dao
{
    class TeacherRepository
    {
        public void Read()
        {

            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from Teacher";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.PersonalIdentityNumber = reader.GetString(0);
                    teacher.FirstName = reader.GetString(1);
                    teacher.LastName = reader.GetString(2);
                    teacher.Gender = (EGender)Enum.Parse(typeof(EGender), char.ToUpper(reader.GetString(3)[0]) + reader.GetString(3).Substring(1));
                    teacher.Address = AddressManager.GetInstance().GetAddressById(reader.GetInt32(4));
                    teacher.Email = reader.GetString(5);
                    teacher.Password = reader.GetString(6);
                    teacher.UserType = (EUserType)Enum.Parse(typeof(EUserType), char.ToUpper(reader.GetString(7)[0]) + reader.GetString(7).Substring(1));
                    teacher.Active = reader.GetBoolean(8);
                    teacher.WorkingSchool = SchoolManager.GetInstance().GetSchoolById(reader.GetInt32(9));
                    teacher.TeachingLanguages = initializeLanguages(teacher.PersonalIdentityNumber);
                    TeacherManager.GetInstance().AllTeachers.Add(teacher);
                }
                conn.Close();
            }
        }

        public void Create(string firstName, string lastName, string personalIdentityNumber, string email, string password, EUserType userType, EGender gender, Address address, bool active, School workingSchool, List<Language> teachingLanguages, List<Session> sessions)
        {
            Teacher teacher = new Teacher(firstName, lastName, personalIdentityNumber, email, password, userType, gender, address, active, workingSchool, teachingLanguages, sessions);
            TeacherManager.GetInstance().AllTeachers.Add(teacher);
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into Teacher values(@personalIdentityNumber ,@first_name, @last_name, @gender, @address_id, @email, @pass, @u_role, @is_active, @working_at)", conn))
                {
                    cmd.Parameters.AddWithValue("@personalIdentityNumber", personalIdentityNumber);
                    cmd.Parameters.AddWithValue("@first_name", firstName);
                    cmd.Parameters.AddWithValue("@last_name", lastName);
                    cmd.Parameters.AddWithValue("@gender", gender.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@address_id", address.Id);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@u_role", userType.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@is_active", 1);
                    cmd.Parameters.AddWithValue("@working_at", workingSchool.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(string firstName, string lastName, string personalIdentityNumber, string email, string password, EUserType userType, EGender gender, Address address, bool active, School workingSchool, List<Language> teachingLanguages, List<Session> sessions)
        {
            Teacher teacher = TeacherManager.GetInstance().GetTeacherByIdentityNumber(personalIdentityNumber);
            teacher.FirstName = firstName;
            teacher.LastName = lastName;
            teacher.Email = email;
            teacher.Password = password;
            teacher.UserType = userType;
            teacher.Gender = gender;
            teacher.Address = address;
            teacher.Active = active;
            teacher.WorkingSchool = workingSchool;
            teacher.TeachingLanguages = teachingLanguages;
            teacher.Sessions = sessions;
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Teacher set  first_name=@first_name, last_name=@last_name, gender=@gender, address_id=@address_id, email=@email, pass=@pass, working_at=@working_at  where personalIdentityNumber=@personalIdentityNumber", conn))
                {
                    cmd.Parameters.AddWithValue("@personalIdentityNumber", personalIdentityNumber);
                    cmd.Parameters.AddWithValue("@first_name", firstName);
                    cmd.Parameters.AddWithValue("@last_name", lastName);
                    cmd.Parameters.AddWithValue("@gender", gender.ToString().ToLower());
                    cmd.Parameters.AddWithValue("@address_id", address.Id);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@working_at", workingSchool.Id);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            DBHandler.DeleteFromTeachesBasedByTeacherID(personalIdentityNumber);

            teachingLanguages.ForEach(lang => DBHandler.InsertIntoTeaches(lang.Id, personalIdentityNumber));
        }

        public void Delete(string personalIdentityNumber)
        {
            Teacher teacher = TeacherManager.GetInstance().GetTeacherByIdentityNumber(personalIdentityNumber);
            teacher.Active = false;
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Teacher set is_active=0 where personalIdentityNumber=@personalIdentityNumber", conn))
                {
                    cmd.Parameters.AddWithValue("@personalIdentityNumber", personalIdentityNumber);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private List<Language> initializeLanguages(string teacherID)
        {
            List<Language> schoolLanguageList = new List<Language>();

            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = $"select language_id from teaches where teacher_id = @teacher_id";
                command.Parameters.AddWithValue("@teacher_id", teacherID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader.GetInt32(0).ToString());
                    Language language = LanguageManager.GetInstance().GetLanguageById(reader.GetInt32(0));
                    Console.WriteLine(language.ToString());
                    schoolLanguageList.Add(language);
                }

                conn.Close();
            }
            return schoolLanguageList;
        }

        private List<Session> initializeSession(string teacherID)
        {
            List<Session> sessionList = new List<Session>();

            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = $"select id from Session where teacher_id = @teacher_id";
                command.Parameters.AddWithValue("@teacher_id", teacherID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader.GetInt32(0).ToString());
                    Session session = SessionManager.GetInstance().GetSessionById(reader.GetInt32(0));
                    sessionList.Add(session);
                }

                conn.Close();
            }
            return sessionList;
        }
    }
}
