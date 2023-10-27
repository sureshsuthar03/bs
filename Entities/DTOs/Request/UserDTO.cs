using CommanLayer.Enum;
using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs.Request
{
    public class UserDTO: BaseValidationModel<UserDTO>
    {
        public string? Name { get; set; }        
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public UserStatus Status { get; set; }
        public UserRole Role { get; set; }
    }
}   
