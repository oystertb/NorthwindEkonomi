using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetListByCategories(int categoryId);
        Product Insert(Product product);
    }
}
