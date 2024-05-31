using FluentValidation;
using IzometriService.Core.Constants;
using IzometriService.Core.Models.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace IzometriService.Business.ValidationRules.FluentValidation.API.UserValidation
{
    public class PostDepartmentValidator : AbstractValidator<BaseDepartmentModel>
    {
        public PostDepartmentValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull()
                .WithMessage(ResultMessages.IsNullAndIsEmpty);


        }
    }
}
