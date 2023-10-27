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
    public class UpdateProfileValidationRule:AbstractValidator<UpdateUserDTO>
    {
        public UpdateProfileValidationRule() 
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull()
                .Length(2, 64);
            RuleFor(p => p.Email)
                .NotEmpty().NotNull()
                .Matches(ValidationPattern.EMAIL).WithMessage(ValidationMsg.Email)
                .Length(2, 64);
            RuleFor(p => p.Status)
                .NotEmpty().NotNull();
            RuleFor(p => p.Role)
                .NotEmpty().NotNull();
        }    
    }
}
