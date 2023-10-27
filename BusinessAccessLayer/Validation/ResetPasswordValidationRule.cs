using CommanLayer.Messages;
using CommanLayer.Pattern;
using EntitiesLayer.DTOs.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Validation
{
    public class ResetPasswordValidationRule: AbstractValidator<ResetPasswordDTO>
    {
        public ResetPasswordValidationRule() 
        {
            RuleFor(p => p.Password)
                .NotEmpty().NotNull()
                .Matches(ValidationPattern.PASSWORD).WithMessage(ValidationMsg.Password);
            RuleFor(p => p.ConfirmPassword)
                .NotEmpty().NotNull()
                .Equal(e => e.Password).WithMessage(ValidationMsg.ConfirmPassword);
        }    
    }
}
