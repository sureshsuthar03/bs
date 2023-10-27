using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs.Response
{
    public class SuccessResponseModel<T>: ErrorResponseModel
    {
        public T? Content { get; set; }
        public SuccessResponseModel(int httpStatusCode, string message)
        {
            HttpCode = httpStatusCode;
            Message.Add(message);           
            IsSuccess = true;
        }
        public SuccessResponseModel(int httpStatusCode,string message,T content)
        {
            HttpCode=httpStatusCode;
            Message.Add(message);    
            Content=content;
            IsSuccess=true; 
        }
    }
}
