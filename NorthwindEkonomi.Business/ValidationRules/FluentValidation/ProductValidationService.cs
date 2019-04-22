using EkonomiCore.CrossCuttingConcern.Validation;
using EkonomiCore.CrossCuttingConcern.Validation.FluentValidation;
using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.Business.ValidationRules.FluentValidation
{
    public class ProductValidationService : IValidationService<Product>
    {
        public void Validate(Product obj)
        {
            var validator = new ProductValidator();

            FluentValidator.Validate(new ProductValidator(), obj);
        }
    }
}
