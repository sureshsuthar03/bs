using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer.CustomException
{
    public class ModelValidationException:Exception
    {
        public List<string> Errors { get; set; }    
        public ModelValidationException()
        { }   
        public ModelValidationException(string message) : base(message) 
        { }
        public ModelValidationException(string message,Exception inner) :base(message, inner)   
        { }
        public ModelValidationException(List<string> message) : base()
        {
            Errors = message;
        }
    }
}
