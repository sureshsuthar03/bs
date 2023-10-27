using EntitiesLayer.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Utils
{
    public class SuccessResponseUtil<T> where T : class
    {
        public IActionResult GetSuccessResponse(int httpcode, string message)
        {
            SuccessResponseModel<T> response = new(httpcode, message);
            return new ObjectResult(response)
            {
                StatusCode = response.HttpCode,
            };
        }
        public IActionResult GetSuccessResponse(int httpcode, string message,T content)
        {
            SuccessResponseModel<T> response = new(httpcode, message,content);
            return new ObjectResult(response)
            {
                StatusCode = response.HttpCode,
            };
        }
    }
}
