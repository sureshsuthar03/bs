using AutoMapper;
using BusinessAccessLayer.Services.Interface;
using CommanLayer.CustomException;
using CommanLayer.Messages;
using DataAccessLayer.Repository.Implement;
using DataAccessLayer.Repository.Interface;
using EntitiesLayer.DTOs.Request;
using EntitiesLayer.Entities;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Implement
{
    public class AuthenticationService : BaseService<User>, IAuthenticationService
    {        
        private readonly IConfiguration _config;
        public readonly IAuthenticationRepository _authenticationRepository;
        public new readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IMailService _mailService;
        public readonly IJwtManageRepository _jwtManageRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository,
            IConfiguration config, IUnitOfWork unitOfWork, IMapper mapper, IMailService mailService, IJwtManageRepository jwtManageRepository)
            : base(authenticationRepository, unitOfWork)
        {
            _authenticationRepository = authenticationRepository;
            _config = config;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mailService = mailService;
            _jwtManageRepository = jwtManageRepository; 
        }

        public async Task<TokenDTO> Login(LoginDTO loginDetails)
        {
            User user = await _authenticationRepository.GetUserByEmail(loginDetails.Email) ?? throw new InvalidCrendtialException(ExceptionMsg.INVALID_CRENDTIAL);
            if (user.Password != loginDetails.Password) throw new InvalidCrendtialException(ExceptionMsg.INVALID_CRENDTIAL);
            TokenDTO token = _jwtManageRepository.GenerateToken(user) ?? throw new Exception("Invalid Attempt");
            UserRefreshTokens userRefreshTokens = new()
            {
                RefreshToken = token.RefreshToken,
                Email = loginDetails.Email, 
            };
            _authenticationRepository.AddUserRefreshToken(userRefreshTokens);
            _unitOfWork.Save();
            return token;
        }

        public async Task<TokenDTO> RefreshToken(TokenDTO token)
        {
            var principal = _jwtManageRepository.GetPrincipalFormExpiredToken(token.AccessToken);
            var email = principal.FindFirstValue(ClaimTypes.Email);
            var savedRefreshToken = _authenticationRepository.GetUserRefreshTokens(email,token.RefreshToken);
            var newJwtToken = _jwtManageRepository.GenerateRefreshToken(await _authenticationRepository.GetUserByEmail(email));
            if (savedRefreshToken.RefreshToken != token.RefreshToken || newJwtToken == null) throw new Exception("invalid attempt");

            UserRefreshTokens userRefreshTokens = new()
            {
                RefreshToken = newJwtToken.RefreshToken,
                Email = email,
            };
            _authenticationRepository.DeleteUserRefreshToken(email,token.RefreshToken);
            _authenticationRepository.AddUserRefreshToken(userRefreshTokens);
            _unitOfWork.Save();
            return newJwtToken;
        }
        public async Task<TokenDTO> PrivateLogin(string userToken)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new()
            {
                Audience = new List<string>() { "490497750098-ar0eaq7j1fkaku1mvomih602rcht6ph5.apps.googleusercontent.com" }
            };
            GoogleJsonWebSignature.Payload payload = GoogleJsonWebSignature.ValidateAsync(userToken, settings).Result;
            if (await _authenticationRepository.GetUserByEmail(payload.Email) == null)
            {
                User userDetails = new()
                {
                    Email = payload.Email,
                    Name = payload.Name
                };
                await AddAsync(userDetails);
            }
            var user = await _authenticationRepository.GetUserByEmail(payload.Email);
            TokenDTO token = _jwtManageRepository.GenerateToken(user) ?? throw new Exception("Invalid Attempt");
            UserRefreshTokens userRefreshTokens = new()
            {
                RefreshToken = token.RefreshToken,
                Email = user.Email,
            };
            _authenticationRepository.AddUserRefreshToken(userRefreshTokens);
            _unitOfWork.Save();
            return token;
        }

        public async Task ForgotPassword(ForgotPasswordDTO emailDetails)
        {
            if (await _authenticationRepository.GetUserByEmail(emailDetails.Email) == null) throw new InvalidCrendtialException(ResponseMsg.MailSent);
            string mailToken = EncodingMailToken(emailDetails.Email);
            MailDTO mailDTO = new()
            {
                ToEmail = emailDetails.Email,
                Body = "https://localhost:4200/ResetPassword?token=" + mailToken + " <br> token valid for 10 minutes only",
            };
            await _mailService.SendMailAsync(mailDTO);
        }

        public async Task ResetPassword(string password, string token)
        {
            DateTime dateTime = Convert.ToDateTime(DecodingMailToken(token).Split("&")[1]);
            if (dateTime.AddMinutes(10) < DateTime.Now) { throw new Exception(ExceptionMsg.TOKEN_EXPIRE); }
            User user = await _authenticationRepository.GetUserByEmail(DecodingMailToken(token).Split("&")[0]);
            user.Password = password;
            await UpdateAsync(user);
        }

        public async Task Register(UserDTO userDetails)
        {
            if (await _authenticationRepository.GetUserByEmail(userDetails.Email) != null) throw new InvalidCrendtialException(ExceptionMsg.EMAIL_EXITS);
            User user = _mapper.Map<User>(userDetails);
            await AddAsync(user);
        }

        //public string GenerateToken(User user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier,user.Name),
        //        new Claim(ClaimTypes.Role,user.Role.ToString()),
        //        new Claim(ClaimTypes.Email,user.Email)
        //    };
        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //        _config["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(60),
        //        signingCredentials: credentials);
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        public string EncodingMailToken(string email)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(email + "&" + DateTime.Now));
        }
        public string DecodingMailToken(string token)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(token));
        }

    }
}
