using FluentValidation;
using IzometriService.Core.Constants;
using IzometriService.Core.Models.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace IzometriService.Business.ValidationRules.FluentValidation.API.UserValidation
{
    internal class PostUserValidator : AbstractValidator<BaseUserModel>
    {
        public PostUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .NotNull()
                .WithMessage(ResultMessages.IsNullAndIsEmpty);

            RuleFor(x => x.LastName).NotEmpty()
               .NotNull()
               .WithMessage(ResultMessages.IsNullAndIsEmpty);

            When(x => !string.IsNullOrEmpty(x.Email), () =>
            {
                RuleFor(x => x.Email)
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage(ResultMessages.IsValidEmail);
            });

        }
    }
}
