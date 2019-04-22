using EkonomiCore.DataAccess;
using NorthwindEkonomi.DataAccess.Abstract;
using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.DataAccess.Concrete.EntityFramework
{
    public class CategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
    {
        public CategoryDal(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
