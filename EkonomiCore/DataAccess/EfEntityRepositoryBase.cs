using EkonomiCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.DataAccess
{
    public abstract class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity: class //generic constraint
    {
        private DbContext _dbContext; // default da da private zaten.

        public EfEntityRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public bool IsAny(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().Any(filter);
        }

        public TEntity Update(TEntity entity)
        {
            DbEntityEntry entry = _dbContext.Entry(entity);
            entry.State = System.Data.Entity.EntityState.Modified;

            _dbContext.SaveChanges();

            return entity;
        }
    }
}
