﻿using EkonomiCore.DataAccess;
using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.DataAccess.Abstract
{
    public interface IProductDal :IEntityRepository<Product>
    {
        //Entity Repository dışında Product ile ilgili bir ihtiyaç olursa burda belirtiyoruz.
        //List<Product> GetByCategory(int categoryId);
    }
}
