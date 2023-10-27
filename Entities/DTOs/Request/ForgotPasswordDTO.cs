using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs.Request
{
    public class ForgotPasswordDTO:BaseValidationModel<ForgotPasswordDTO>
    {
        public string Email { get; set; } = null!;   
    }
}
