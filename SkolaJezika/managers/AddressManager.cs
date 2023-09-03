using SR05-2021-POP2022.exceptions;
using SR05-2021-POP2022.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SR05-2021-POP2022.managers
{
    class AddressManager
    {
        private static AddressManager instance;
        private ObservableCollection<Address> allAddresses = new ObservableCollection<Address> ();

        public ObservableCollection<Address> AllAddresses { get => allAddresses; set => allAddresses = value; }

        private AddressManager() { }

        public static AddressManager GetInstance()
        {
            if (instance == null) instance = new AddressManager();
            return instance;
        }

        public Address GetAddressById(int id)
        {
            Address foundAddress = allAddresses.ToList().Find(x => x.Id == id);
            if (foundAddress == null)
            {
                throw new AddressNotFoundException("Adresa nije pronadjena");
            }
            return foundAddress;
        }

        public Address GetAddressByStreetName(string name)
        {

            Address foundAddress = allAddresses.ToList().Find(x => x.Street == name);
            if (foundAddress == null)
            {
                throw new AddressNotFoundException("Adresa nije pronadjena");
            }
            return foundAddress;
        }

        public Address GetAddressByStreetNameAndNumber(string name, int number)
        {
            Address foundAddress = allAddresses.ToList().Find(x => x.Street == name && x.Number == number);
            if (foundAddress == null)
            {
                throw new AddressNotFoundException("Adresa nije pronadjena");
            }
            return foundAddress;
        }

        public Address GetAddressByStreetNameNumberAndCity(string name, int number, string city)
        {
            Address foundAddress = allAddresses.ToList().Find(x => x.Street == name && x.Number == number && x.City == city);
            if (foundAddress == null)
            {
                throw new AddressNotFoundException("Adresa nije pronadjena");
            }
            return foundAddress;
        }
    }
}
