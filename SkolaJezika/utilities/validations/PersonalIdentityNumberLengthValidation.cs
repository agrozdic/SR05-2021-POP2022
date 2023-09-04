using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SkolaJezika.utilities.validations
{
    class PersonalIdentityNumberLengthValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length == 13)
            {
                return new ValidationResult(true, "");
            }
            return new ValidationResult(false, "Personal Identity Number must be 13 characters!");
        }
    }
}
