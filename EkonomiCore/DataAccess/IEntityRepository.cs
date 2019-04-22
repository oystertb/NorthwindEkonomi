using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.DataAccess
{
    //Generic. Nesne istiyor(TEntity)
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter); //
        bool IsAny(Expression<Func<TEntity,bool>> filter);
    }
}
