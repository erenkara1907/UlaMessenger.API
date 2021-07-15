using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class GroupValidator : AbstractValidator<Group>
    {
        public GroupValidator()
        {
            RuleFor(g => g.GroupName).NotEmpty().WithMessage("Grup adı gereklidir");
        }
    }
}
