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
            return Validate(@"^(([\w]+\.?){0,2}([\w]+))@(([\w]*\.?)?([\w]+))\.(\w{2,3})$", email, "Please enter a valid emailaddress");
        }
        public static bool ValidateName(string name)
        {
            return Validate(@"^[A-ZÅÄÖ]{1}\w{1,10}-?([A-ZÅÄÖ]{1}\w{1,10})?$", name, "Please enter a valid name");            
        }
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            return Validate(@"^\d{10}$", phoneNumber, "Please enter a valid phonenumber");
        }
        private static bool Validate(string pattern, string str, string err)
        {
            Regex r = new Regex(pattern);
            Match m = r.Match(str);
            if (m.Success)
            {
                return true;
            }
            else
            {
                Console.WriteLine(err);
                return false;
            }
        }
    }
}
