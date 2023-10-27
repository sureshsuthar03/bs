using EntitiesLayer.DTOs.Request;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Interface
{
    public interface IProfileService:IBaseService<User>
    {
        Task UpdateProfile(UpdateUserDTO userDetails);
        Task ChangePassword(ChangedPasswordDTO passwordDetails);
    }
}
