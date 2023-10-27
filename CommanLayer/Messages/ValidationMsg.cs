using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer.Messages
{
    public class ValidationMsg
    {
        public const string Email = "Enter a valid email address";
        public const string Password = "Password should be 8-15 charater and must contain 1 smallcase,1 capital,1 symbol,1 number";
        public const string ConfirmPassword = "Password is not match with confirm password";
        public const string Empty = "Can't enter empty";
    }
}
