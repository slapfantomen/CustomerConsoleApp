using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerConsoleApp
{
    public static class Validator
    {
        public static bool ValidateEmail(string email)
        {
            return Validate(@"^(([\w]+\.?){0,2}([\w]+))@(([\w]*\.?)?([\w]+))\.(\w{2,3})$", email);
        }
        public static bool ValidateName(string name)
        {
            return Validate(@"^[A-ZÅÄÖ]{1}\w{1,10}-?([A-ZÅÄÖ]{1}\w{1,10})?$", name);            
        }
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            return Validate(@"^\d{10}$", phoneNumber);
        }
        private static bool Validate(string pattern, string str)
        {
            Regex r = new Regex(pattern);
            Match m = r.Match(str);
            return m.Success;
        }
    }
}
