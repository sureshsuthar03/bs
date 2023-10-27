using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs.Request
{
    public class LoginDTO:BaseValidationModel<LoginDTO>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set;} = null!;
    }
}
