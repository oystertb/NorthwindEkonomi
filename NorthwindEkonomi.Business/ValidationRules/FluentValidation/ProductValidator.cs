using FluentValidation;
using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.UnitPrice).NotEqual(0);
            RuleFor(t => t.Description).Length(3, 250); //zorunlu değil ama eğer adam girerse min 3 max 250.
        }
    }
}
