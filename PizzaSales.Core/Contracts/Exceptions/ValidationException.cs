using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSales.Core.Contracts.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; } = [];

        public ValidationException(ValidationResult result)
        {
            foreach (var item in result.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
        }

        public ValidationException(Dictionary<string, string> result)
        {
            foreach (var item in result)
            {
                ValidationErrors.Add(item.Value);
            }
        }

        public ValidationException(string message)
        {
            ValidationErrors.Add(message);
        }
    }
}
