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
    public class TitleRule : JukeboxBaseValidationRule
    {

        private static Regex _titleRegex;

        public string TitleRegexPattern
        {
            get
            {
                return TitleRegex.ToString();
            }
            set
            {
                TitleRegex = new Regex((String)value);
            }
        }

        public static Regex TitleRegex
        {
            get
            {
                if (_titleRegex == null)
                    _titleRegex = new Regex("^[\\s\\@\\!\\?\"\'\\;\\:a-zA-Z0-9.,_-]{1,40}$");
                return _titleRegex;
            }
            set { _titleRegex = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string title = "";
            title = (String)GetBoundValue(value);
            if (TitleRegex.IsMatch(title))
            {
                return new ValidationResult(true, null);
            } else
            {
                return new ValidationResult(false, "Title must have at least 1 character and have less than or equal to 40 characters.");
            }
        }
    }
}
