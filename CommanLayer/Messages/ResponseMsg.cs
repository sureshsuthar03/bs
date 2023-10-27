using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer.Messages
{
    public class ResponseMsg
    {
        public const string Login = "Loggin Successfull!";
        public const string Register = "Registration Successfull!";
        public const string MailSent = "Mail has been sent to registered mailId";
        public const string PasswordChanged = "Your password has been changed";
        public const string DataFatch = "Data fatch";
        public const string Create = "Entity added successfull";
        public const string Update = "Entity updated successfull";
        public const string Delete = "Entity deleted Successfull";
    }
}
