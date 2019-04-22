using EkonomiCore.CrossCuttingConcern.Validation;
using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.Business.ValidationRules
{
    public class MyProductValidatorService : IValidationService<Product>
    {
        //Bu ilkel bir yöntem. Bunun yerine validasyon framework ü kullanacağız.
        public void Validate(Product product)
        {
            //validasyon
            if (string.IsNullOrEmpty(product.Name))
                throw new Exception("Ürün adı zorunludur!");
            if (product.UnitPrice == 0)
                throw new Exception("Fiyat sıfırdan büyük girilmelidir!");
        }
    }
}
