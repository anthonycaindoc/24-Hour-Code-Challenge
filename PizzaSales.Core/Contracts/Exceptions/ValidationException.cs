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

        public ValidationException(string message)
        {
            ValidationErrors.Add(message);
        }
    }
}
