using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.utilities.exceptions
{
    class SessionNotFoundException : Exception
    {

        public SessionNotFoundException()
        {

        }

        public SessionNotFoundException(string message) : base(message)
        {

        }

        public SessionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
