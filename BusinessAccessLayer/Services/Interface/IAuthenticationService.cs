using EntitiesLayer.DTOs.Request;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Interface
{
    public interface IAuthenticationService:IBaseService<User>
    {
        Task<TokenDTO> Login(LoginDTO loginDetails);
        Task<TokenDTO> PrivateLogin(string userToken);
        Task ForgotPassword(ForgotPasswordDTO emailDetails);
        Task ResetPassword(string password,string token);
        Task Register(UserDTO userDetails);
        Task<TokenDTO> RefreshToken(TokenDTO token);
    }
}
