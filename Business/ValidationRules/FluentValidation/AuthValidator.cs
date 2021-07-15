using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator:AbstractValidator<User>
    {
        public AuthValidator()
        {
            RuleFor(a => a.PhoneNumber).NotEmpty().WithMessage("Telefon numarası gereklidir");
        }
    }
}
