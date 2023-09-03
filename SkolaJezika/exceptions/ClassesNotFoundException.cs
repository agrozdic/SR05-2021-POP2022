using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.exceptions
{
    class ClassesNotFoundException : Exception
    {

        public ClassesNotFoundException()
        {

        }

        public ClassesNotFoundException(string message) : base(message)
        {

        }

        public ClassesNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
