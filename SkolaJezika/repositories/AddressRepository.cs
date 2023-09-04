using SkolaJezika.managers;
using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.IO;

namespace SkolaJezika.repositories
{
    class AddressRepository
    {
        public void Read()
        {

            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from Address";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Address address = new Address();
                    address.Id = reader.GetInt32(0);
                    address.Street = reader.GetString(1);
                    address.Number = reader.GetInt32(2);
                    address.City = reader.GetString(3);
                    address.Country = reader.GetString(4);
                    address.Active = reader.GetBoolean(5);
                    AddressManager.GetInstance().AllAddresses.Add(address);
                }

                conn.Close();
            }

        }

        public void Create(string street, int number, string city, string country, bool active = true)
        {
            int id = IDGenerator.GenerateAddressID();
            Address address = new Address(id, street, number, city, country, active);
            AddressManager.GetInstance().AllAddresses.Add(address);
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into Address values(@id ,@street, @address_number, @city, @country, @is_active)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@street", street);
                    cmd.Parameters.AddWithValue("@address_number", number);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@is_active", 1);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(int id, string street, int number, string city, string country)
        {
            Address address = AddressManager.GetInstance().GetAddressById(id);
            address.Street = street;
            address.Number = number;
            address.City = city;
            address.Country = country;
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Address set street=@street,address_number=@address_number,city=@city,country=@country where id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@street", street);
                    cmd.Parameters.AddWithValue("@address_number", number);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@country", country);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(int id)
        {
            Address updatedAddress = AddressManager.GetInstance().GetAddressById(id);
            updatedAddress.Active = false;
            using (SqlConnection conn = new SqlConnection(DBHandler.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Address set is_active = 0 where id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
