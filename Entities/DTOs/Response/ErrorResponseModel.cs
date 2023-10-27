using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs.Response
{
    public class ErrorResponseModel
    {
        public int HttpCode { get; set; }
        
        public Boolean IsSuccess { get; set; }

        public List<string> Message { get; set; } = new();
    }
}

