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
    public class ForgotPasswordValidationRule: AbstractValidator<ForgotPasswordDTO>
    {
        public ForgotPasswordValidationRule()
        {
            RuleFor(p => p.Email)
                .NotEmpty().NotNull()
                .Matches(ValidationPattern.EMAIL).WithMessage(ValidationMsg.Email)
                .Length(2, 64);
        }
    }
}
