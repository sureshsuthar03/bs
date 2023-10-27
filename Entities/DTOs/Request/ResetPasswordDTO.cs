using EntitiesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs.Request
{
    public class ResetPasswordDTO: BaseValidationModel<ResetPasswordDTO>
    {
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
