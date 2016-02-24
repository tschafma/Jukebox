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
    public class DurationRule : JukeboxBaseValidationRule
    {

        private static Regex _durationRegex;

        public string DurationRegexPattern
        {
            get { return DurationRegex.ToString(); }
            set
            {
                DurationRegex = new Regex((String)value);
            }
        }

        public static Regex DurationRegex
        {
            get
            {
                if (_durationRegex == null)
                    _durationRegex = new Regex("^([0-9][0-9]):([0-6][0-9])$");
                return _durationRegex;
            }
            set
            {
                _durationRegex = value;
            }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string duration = "";
            duration = (String)GetBoundValue(value);
            if (DurationRegex.IsMatch(duration))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Duration must follow the format 00:00");
            }
        }
    }
}
