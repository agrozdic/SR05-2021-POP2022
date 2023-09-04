using SkolaJezika.resources.managers;
using SkolaJezika.utilities.file_related_utilities;
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
    class LanguageRepository
    {
        public void Read()
        {
            
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from Language";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Language language = new Language();
                    language.Id = reader.GetInt32(0);
                    language.LanguageName = reader.GetString(1);
                    language.Active = reader.GetBoolean(2);
                    LanguageManager.GetInstance().AllLanguages.Add(language);
                }

                conn.Close();
            }
        }

        public void Create(string languageName, bool active = true)
        {
            int id = IDGenerator.GenerateLanguageID();
            Language language = new Language(id, languageName, active);
            LanguageManager.GetInstance().AllLanguages.Add(language);
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into Language values(@id ,@lang_name, @is_active)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", languageName);
                    cmd.Parameters.AddWithValue("@is_active", 1);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(int id, string languageName)
        {
            Language language = LanguageManager.GetInstance().GetLanguageById(id);
            language.LanguageName = languageName;
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Language set lang_name=@lang_name where id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@lang_name", languageName);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(int id)
        {
            Language language = LanguageManager.GetInstance().GetLanguageById(id);
            language.Active = false;
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Language set is_active = 0 where id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
