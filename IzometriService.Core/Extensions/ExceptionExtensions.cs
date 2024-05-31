using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IzometriService.Core.Extensions
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<string> ToErrorList(this Exception e)
        {
            if (e is ValidationException validationException)
            {
                return validationException.Errors.Select(x => x.PropertyName + " : " + x.ErrorMessage);
            }

            return new List<string>();
        }
    }
}
