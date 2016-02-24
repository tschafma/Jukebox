using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Jukebox.Helpers.Validation
{
    public class RequiredRule : JukeboxBaseValidationRule
    {

        private static Regex _requiredRegex;

        public static Regex RequiredRegex
        {
            get
            {
                if (_requiredRegex == null)
                    _requiredRegex = new Regex("^[\\s\\S]{1,}$");
                return _requiredRegex;
            }
            set { _requiredRegex = value; }
        }

        public string RequiredRegexPattern
        {
            get
            {
                return RequiredRegex.ToString();
            }
            set
            {
                if (RequiredRegex == null)
                    RequiredRegex = new Regex(value);
            }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string val = "";
            val = (String)GetBoundValue(value);
            if (RequiredRegex.IsMatch(val))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Field cannot be empty");
            }
        }
    }
}
