using Azure;
using CommanLayer.CustomException;
using CommanLayer.Messages;
using EntitiesLayer.DTOs.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Mail;

namespace BillingSystemServer.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex) 
            {
                await HandleExceptionAsync(context,ex);
            }
        }
        async Task HandleExceptionAsync(HttpContext context,Exception ex)
        {
            context.Response.ContentType = "application/json";  

            string jsonResponse = JsonConvert.SerializeObject(GenerateResponse(context, ex));
            await context.Response.WriteAsync(jsonResponse);
        }
        static ErrorResponseModel GenerateResponse(HttpContext context, Exception ex)
        {
            List<string> message = new List<string>();
            int errorCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = errorCode;

            void SetResponse(int httpCode, string messages)
            {
                message.Add(messages);
                errorCode = httpCode;
            }

            switch (ex)
            {
                case MissingFieldException:
                    SetResponse((int)HttpStatusCode.InternalServerError,ExceptionMsg.MISSINGFIELD);
                    break;
                case SmtpException:
                    SetResponse((int)HttpStatusCode.InternalServerError, ExceptionMsg.MISSINGFIELD);
                    break;
                case ModelValidationException modelValidationException:
                    message = modelValidationException.Errors;
                    errorCode = (int)HttpStatusCode.InternalServerError;    
                    break;
                case InvalidCrendtialException invalidCrendtialException:
                    SetResponse((int)HttpStatusCode.InternalServerError, invalidCrendtialException.Message);
                    break;
                default:
                    message.Add(ex.Message);
                    break;
            }

            return new ErrorResponseModel()
            {
                HttpCode = errorCode,
                IsSuccess = false,
                Message=message
            };
        }
    }
}
