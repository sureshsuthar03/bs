using EntitiesLayer.DTOs.Request;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interface
{
    public interface IJwtManageRepository
    {
        TokenDTO GenerateToken(User user);
        TokenDTO GenerateRefreshToken(User user);
        ClaimsPrincipal GetPrincipalFormExpiredToken(string token);
    }
}
