using EkonomiCore.DataAccess;
using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        //Category Insert(Category category);
        //Category Update(Category category);
        //void Delete(Category category);
        //List<Category> Getall();
    }
}
