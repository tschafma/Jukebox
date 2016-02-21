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
    public class UsernameRule : JukeboxBaseValidationRule
    {

        private static Regex _usernameRegex;

        public UsernameRule()
        {
        }

        public string UsernameRegexPattern
        {
            get { return _usernameRegex.ToString(); }
            set
            {
                _usernameRegex = new Regex(value);
            }
        }

        public static Regex UsernameRegex
        {
            get
            {
                if (_usernameRegex == null)
                    _usernameRegex = new Regex("^[a-zA-Z0-9_]{6,}$");
                return _usernameRegex;
            }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = "";
            input = (String)GetBoundValue(value);
            if (UsernameRegex.IsMatch(input))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Username must be greater than 6 characters. can contain letters, numbers, and underscores.");
            }
        }
    }
}
