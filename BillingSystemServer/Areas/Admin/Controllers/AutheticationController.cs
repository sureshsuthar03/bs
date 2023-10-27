using BillingSystemServer.ValidationFilter;
using BusinessAccessLayer.Services.Interface;
using BussinessAccessLayer.Utils;
using CommanLayer.Messages;
using CommanLayer.Validation;
using EntitiesLayer.DTOs.Request;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;

namespace BillingSystemServer.Areas.Admin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutheticationController : ControllerBase
    {
        public readonly IAuthenticationService _authenticationService;
        public AutheticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        [ValidationModel]
        public async Task<IActionResult> Login(LoginDTO loginDetails)
        {
            return new SuccessResponseUtil<object>().GetSuccessResponse
                ((int)HttpStatusCode.OK, ResponseMsg.Login, await _authenticationService.Login(loginDetails));
        }

        [HttpPost("PrivateLogin")]
        [ValidationModel]
        public async Task<IActionResult> PrivateLogin(string token)
        {
            return new SuccessResponseUtil<object>().GetSuccessResponse
                ((int)HttpStatusCode.OK, ResponseMsg.Login, await _authenticationService.PrivateLogin(token));
        }

        [HttpPost("ForgotPassword")]
        [ValidationModel]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO emailDetails)
        {
            await _authenticationService.ForgotPassword(emailDetails);
            return new SuccessResponseUtil<object>().GetSuccessResponse
                ((int)HttpStatusCode.OK, ResponseMsg.MailSent);
        }

        [HttpPost("ResetPassword")]
        [ValidationModel]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO passwordDetails,string token)
        {
            await _authenticationService.ResetPassword(passwordDetails.Password, token);
            return new SuccessResponseUtil<object>().GetSuccessResponse
                ((int)HttpStatusCode.OK, ResponseMsg.PasswordChanged);
        }

        [HttpPost("Registeration")]
        [ValidationModel]
        public async Task<IActionResult> Register(UserDTO userDetails)
        {
            await _authenticationService.Register(userDetails);
            return new SuccessResponseUtil<object>().GetSuccessResponse
                ((int)HttpStatusCode.OK, ResponseMsg.Register);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(TokenDTO token)
        {
            return new SuccessResponseUtil<object>().GetSuccessResponse
                ((int)HttpStatusCode.OK, "", await _authenticationService.RefreshToken(token));
        }
    }
}
