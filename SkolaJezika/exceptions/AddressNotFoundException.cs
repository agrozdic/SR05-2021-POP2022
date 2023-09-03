using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.exceptions
{
    class AddressNotFoundException : Exception
    {
        public AddressNotFoundException()
        {

        }

        public AddressNotFoundException(string message) : base(message)
        {

        }

        public AddressNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
