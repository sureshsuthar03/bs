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
    public class ProductValidationRule:AbstractValidator<ProductDTO>
    {
        public ProductValidationRule() 
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull();
            RuleFor(p => p.Category)
                .NotEmpty().NotNull();
            RuleFor(p => p.Price)
                .NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
