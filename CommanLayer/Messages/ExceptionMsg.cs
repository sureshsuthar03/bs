using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer.Messages
{
    public class ExceptionMsg
    {
        public static string MISSINGFIELD = "Some Field are mission";
        public static string INVALID_CRENDTIAL = "Email or password is invalid";
        public static string EMAIL_EXITS = "Email is already exits";
        public static string TOKEN_EXPIRE = "Your token has been expire";
    }
}
