using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SkolaJezika.utilities.validations
{
    class MailValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Contains('@') && value.ToString().Contains(".com") && !value.ToString().Equals(""))
            {
                return new ValidationResult(true, "");
            }
            return new ValidationResult(false, "Email must contain @ and .com");
        }
    }
}
