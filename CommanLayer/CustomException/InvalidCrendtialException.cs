using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer.CustomException
{
    public class InvalidCrendtialException:Exception
    {
        public InvalidCrendtialException()
        { }
        public InvalidCrendtialException(string message) : base(message)
        { }
    }
}
