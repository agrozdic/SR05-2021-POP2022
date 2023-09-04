using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.utilities
{
    class DBHandler
    {
        public static readonly String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Desktop\SR05-2021-POP2022\SkolaJezika\Database1.mdf;Integrated Security=True";

        public static void DeleteAllLanguagesFromHasLanguagesBasedBySchoolID(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("DELETE FROM hasLanguage where school_id=@school_id", conn))
                {
                    cmd.Parameters.AddWithValue("@school_id", id);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public static void InsertIntoHasLanguages(int schooldID, int languageID)
        {
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("INSERT INTO hasLanguage VALUES(@school_id, @language_id)", conn))
                {
                    cmd.Parameters.AddWithValue("@school_id", schooldID);
                    cmd.Parameters.AddWithValue("@language_id", languageID);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public static void DeleteFromTeachesBasedByTeacherID(string personalIdentityNumber)
        {
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("DELETE FROM teaches where teacher_id=@teacher_id", conn))
                {
                    cmd.Parameters.AddWithValue("@teacher_id", personalIdentityNumber);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public static void InsertIntoTeaches(int languageID, string teacherID)
        {
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("INSERT INTO teaches VALUES(@language_id, @teacher_id, 1)", conn))
                {
                    cmd.Parameters.AddWithValue("@language_id", languageID);
                    cmd.Parameters.AddWithValue("@teacher_id", teacherID);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
