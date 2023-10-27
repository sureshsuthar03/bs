using DataAccessLayer.ApplicationDbContext;
using DataAccessLayer.Repository.Interface;
using EntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Implement
{
    public class AuthenticationRepository : BaseRepository<User>, IAuthenticationRepository
    {
        public readonly AppDbContext _context;
        public AuthenticationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email) => await _context.Users.Where(user => user.Email == email).FirstOrDefaultAsync();

        public UserRefreshTokens AddUserRefreshToken(UserRefreshTokens user)
        {
            _context.UserRefreshTokens.Add(user);
            return user;
        }

        public void DeleteUserRefreshToken(string email, string refreshToken)
        {
            var item = _context.UserRefreshTokens.FirstOrDefault(x => x.Email == email && x.RefreshToken == refreshToken);
            if (item != null) { _context.Remove(item); }
        }

        public UserRefreshTokens GetUserRefreshTokens(string email, string refreshToken)
        {
            return _context.UserRefreshTokens.FirstOrDefault(x => x.Email == email && x.RefreshToken == refreshToken);
        }
    }
}
