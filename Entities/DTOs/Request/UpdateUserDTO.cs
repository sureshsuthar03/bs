using CommanLayer.Enum;
using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs.Request
{
    public class UpdateUserDTO:BaseValidationModel<UpdateUserDTO>
    {
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
        public UserStatus Status { get; set; }
        public UserRole Role { get; set; }
    }
}
