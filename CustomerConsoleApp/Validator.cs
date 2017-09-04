using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerConsoleApp
{
    class Validator
    {
        public bool ValidateEmail(string email)
        {
            Regex r = new Regex(@"^(([\w]+\.?){0,2}([\w]+))@(([\w]*\.?)?([\w]+))\.(\w{2})$");
            Match m = r.Match(email);
            return m.Success;
        }
    }
}
