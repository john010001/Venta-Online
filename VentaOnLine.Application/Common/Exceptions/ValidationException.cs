using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Application.Common.Exceptions
{
    public class ValidationException: Exception
    {
       
        public ValidationException(ValidationResult validationResult)
        {
            var failures = validationResult.Errors.ToList();
            var messages = new StringBuilder();
            failures.ForEach(f => { messages.Append(f.ErrorMessage + Environment.NewLine); });
            throw new ValidationException(messages.ToString());

        }

        public ValidationException(string message):base(message)
        {                       
        }
    }
}
