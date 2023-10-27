using EntitiesLayer.DTOs.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Validation
{
    public class InvoiceValidationRule : AbstractValidator<InvoiceDTO>
    {
        public InvoiceValidationRule() 
        {
            RuleFor(i=>i.ProductId).NotNull().NotEmpty();
            RuleFor(i => i.UserId).NotNull().NotEmpty();
            RuleFor(i => i.QuantitySold).NotNull().NotEmpty();
            RuleFor(i => i.Amount).NotNull().NotEmpty();
            RuleFor(i => i.TotalAmount).NotNull().NotEmpty();
            RuleFor(i => i.Date).NotNull().NotEmpty();
        }
    }
}
