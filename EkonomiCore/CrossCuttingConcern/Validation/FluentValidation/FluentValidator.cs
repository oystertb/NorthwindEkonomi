using EkonomiCore.CrossCuttingConcern.ExceptionHandling;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = EkonomiCore.CrossCuttingConcern.ExceptionHandling.ValidationException;

namespace EkonomiCore.CrossCuttingConcern.Validation.FluentValidation
{
    public class FluentValidator
    {
        public static void Validate(IValidator validator, object obj)
        {
             var result = validator.Validate(obj);

            //if (!result.IsValid)
            //{

            //}

            foreach (var err in result.Errors)
            {
                throw new ValidationException(err.ErrorMessage); //bizim yarattığımız Exception class
            }
        }
    }
}
