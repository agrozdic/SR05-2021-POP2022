using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.utilities.exceptions
{
    class LanguageNotFoundException : Exception
    {

        public LanguageNotFoundException()
        {

        }

        public LanguageNotFoundException(string message) : base(message)
        {

        }

        public LanguageNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
