using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interface
{
    public interface IAuthenticationRepository:IBaseRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        UserRefreshTokens AddUserRefreshToken(UserRefreshTokens user);   
        UserRefreshTokens GetUserRefreshTokens(string email,string refreshToken);
        void DeleteUserRefreshToken(string email,string refreshToken);
    }
}
