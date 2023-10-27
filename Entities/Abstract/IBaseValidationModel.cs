﻿using CommanLayer.CustomException;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Abstract
{
    public interface IBaseValidationModel
    {
        public void Validate(object validator, IBaseValidationModel modelObj);
    }
    public class BaseValidationModel<T> : IBaseValidationModel
    {
        public void Validate(object validator, IBaseValidationModel modelObj)
        {
            var instance = (IValidator<T>)validator;
            var result = instance.Validate((T)modelObj);

            if(!result.IsValid && result.Errors.Any())
            {
                throw new ModelValidationException(result.Errors.Select(e=>e.ErrorMessage).ToList());
            }
        }
    }
}
