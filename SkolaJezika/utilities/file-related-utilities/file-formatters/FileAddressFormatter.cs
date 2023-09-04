using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.utilities.file_related_utilities
{
    class FileAddressFormatter
    {
        public static Address createAddressFromFile(string[] splittedLine)
        {
            Address address = new Address();
            address.Id = int.Parse(splittedLine[0]);
            address.Street = splittedLine[1];
            address.Number = int.Parse(splittedLine[2]);
            address.City = splittedLine[3];
            address.Country = splittedLine[4];
            address.Active = bool.Parse(splittedLine[5]);
            return address;
        }

        public static string createStringFormatForFileStorage(Address address)
        {
            return String.Format("{0}|{1}|{2}|{3}|{4}|{5}", address.Id, address.Street, address.Number, address.City, address.Country, address.Active);
        }
    }
}
