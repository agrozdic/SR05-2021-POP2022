using SkolaJezika.resources.managers;
using SkolaJezika.utilities.file_related_utilities.file_formatters;
using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using SkolaJezika.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace SkolaJezika.resources.dao
{
    class SessionRepository
    {

        public void Read()
        {
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from Sessions";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Session session = new Session();
                    session.Id = reader.GetInt32(0);
                    session.Teacher = TeacherManager.GetInstance().GetTeacherByIdentityNumber(reader.GetString(1));
                    session.ReservedDate = reader.GetDateTime(2);
                    session.StartingTime = reader.GetTimeSpan(3).ToString();
                    session.ClassLength = reader.GetInt32(4);
                    session.Status = (EClassStatus) Enum.Parse(typeof (EClassStatus), reader.GetString(5));
                    session.Student = reader.IsDBNull(6) ? null :
                        StudentManager.GetInstance().GetStudentByIdentityNumber(reader.GetString(6));
                    session.Active = reader.GetBoolean(7);
                    SessionManager.GetInstance().AllSessions.Add(session);
                }

                conn.Close();
            }
        }

        public void Create(Teacher teacher, DateTime reservedDate, string startingTime, int classLength, EClassStatus status, Student student, bool active = true)
        {
            int id = IDGenerator.GenerateSessionID();
            Session session = new Session(id, teacher, reservedDate, startingTime, classLength, status, student, active);
            SessionManager.GetInstance().AllSessions.Add(session);
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into Sessions values(@id, @teacher, @resdate, @starttime, @duration, @status, @student, @is_active)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@teacher", teacher.PersonalIdentityNumber);
                    cmd.Parameters.AddWithValue("@resdate", reservedDate);
                    cmd.Parameters.AddWithValue("@starttime", TimeSpan.Parse(startingTime));
                    cmd.Parameters.AddWithValue("@duration", classLength);
                    cmd.Parameters.AddWithValue("@status", status.ToString());
                    cmd.Parameters.AddWithValue("@student", DBNull.Value);
                    cmd.Parameters.AddWithValue("@is_active", 1);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(int id, Teacher teacher, DateTime reservedDate, string startingTime, int classLength, EClassStatus status, Student student, bool active = true)
        {
            Session session = SessionManager.GetInstance().GetSessionById(id);
            session.Teacher = teacher;
            session.ReservedDate = reservedDate;
            session.StartingTime = startingTime;
            session.ClassLength = classLength;
            session.Status = status;
            session.Student = student;
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();

                string studentJMBG = session.Student == null ? null : session.Student.PersonalIdentityNumber;

                using (SqlCommand cmd =
                    new SqlCommand("update Sessions set teacher=@teacher,resdate=@resdate,starttime=@starttime,duration=@duration, student=@student, status=@status where id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@teacher", teacher.PersonalIdentityNumber);
                    cmd.Parameters.AddWithValue("@resdate", reservedDate);
                    cmd.Parameters.AddWithValue("@starttime", TimeSpan.Parse("21:00"));
                    cmd.Parameters.AddWithValue("@duration", classLength);
                    if (studentJMBG == null)
                    {
                        cmd.Parameters.AddWithValue("@student", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@student", session.Student.PersonalIdentityNumber);
                    }
                    cmd.Parameters.AddWithValue("@status", status.ToString());

                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public void Update(Session session)
        {
            string studentJMBG = session.Student == null ? null : session.Student.PersonalIdentityNumber;
            
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Sessions set teacher=@teacher,resdate=@resdate,starttime=@starttime,duration=@duration, student=@student, status=@status, is_active=@is_active where id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", session.Id);
                    cmd.Parameters.AddWithValue("@teacher", session.Teacher.PersonalIdentityNumber);
                    cmd.Parameters.AddWithValue("@resdate", session.ReservedDate);
                    cmd.Parameters.AddWithValue("@starttime", session.StartingTime);
                    cmd.Parameters.AddWithValue("@duration", session.ClassLength);
                    if (studentJMBG == null)
                    {
                        cmd.Parameters.AddWithValue("@student", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@student", session.Student.PersonalIdentityNumber);
                    }
                    cmd.Parameters.AddWithValue("@status", session.Status.ToString());
                    cmd.Parameters.AddWithValue("@is_active", session.Active.ToString());
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public void Delete(int id)
        {
            Session session = SessionManager.GetInstance().GetSessionById(id);
            session.Active = false;
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Sessions set is_active=0 where id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void MakeSessionReserved(int sessionID, string studentID)
        {
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into reserved2 values(@session_id, @student_id)", conn))
                {
                    cmd.Parameters.AddWithValue("@session_id", sessionID);
                    cmd.Parameters.AddWithValue("@student_id", studentID);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void MakeSessionAvailable(int sessionID)
        {
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("DELETE FROM reserved2 WHERE session_id=@session_id", conn))
                {
                    cmd.Parameters.AddWithValue("@session_id", sessionID);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
