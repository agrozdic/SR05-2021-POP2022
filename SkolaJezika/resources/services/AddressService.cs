using SkolaJezika.resources.dao;
using SkolaJezika.resources.managers;
using SkolaJezika.utilities.exceptions;
using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace SkolaJezika.resources.services
{
    class AddressService
    {
        AddressRepository repository;
        public AddressService()
        {
            repository = new AddressRepository();
        }

        public void InitializeService()
        {
            FillModelManager(); 
        }

        private void FillModelManager()
        {
            repository.Read();
        }


        public ObservableCollection<String> GetAllCities()
        {
            return new ObservableCollection<string>(GetAllAddresses().ToList().Select(address => address.City).Distinct());
        }

        public ObservableCollection<Address> GetAllAddresses()
        {
            try
            {
                ObservableCollection<Address> address = new ObservableCollection<Address>(AddressManager.GetInstance().AllAddresses.Where(ad => ad.Active).ToList());
                return address;
            }
            catch (AddressNotFoundException exception)
            {
                return new ObservableCollection<Address>();
            }
        }

        public Address GetAddressByID(int id)
        {
            try
            {
                Address address = AddressManager.GetInstance().GetAddressById(id);
                return address;
            }
            catch (AddressNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public Address GetAddressByName(string name)
        {
            try
            {
                Address address = AddressManager.GetInstance().GetAddressByStreetName(name);
                return address;
            }
            catch (AddressNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public Address GetAddressByStreetNameAndNumber(string name, int number)
        {
            try
            {
                Address address = AddressManager.GetInstance().GetAddressByStreetNameAndNumber(name, number);
                return address;
            }
            catch (AddressNotFoundException exception)
            {
                MessageBox.Show($"{exception.Message}");
                return null;
            }

        }

        public Address GetAddressByStreetNameNumberAndCity(string name, int number, string city)
        {
            try
            {
                Address address = AddressManager.GetInstance().GetAddressByStreetNameAndNumber(name, number);
                return address;
            }
            catch (AddressNotFoundException exception)
            {
                MessageBox.Show($"{exception.Message}");
                return null;
            }

        }

        public void CreateAddress( string street, int number, string city, string country)
        {
            repository.Create(street, number, city, country);
        }

        public void UpdateAddress(int id, string street, int number, string city, string country)
        {
            repository.Update(id, street, number, city, country);
        }

        public void DeleteAddress(int id)
        {
            repository.Delete(id);
        }
    }
}
