using EkonomiCore.DataAccess;
using NorthwindEkonomi.DataAccess.Abstract;
using NorthwindEkonomi.DataAccess.Concrete.EntityFramework.Context;
using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.DataAccess.Concrete.EntityFramework
{
    public class ProductDal : EfEntityRepositoryBase<Product>, IProductDal
    {
        //private readonly DbContext _dbContext;

        public ProductDal(DbContext dbContext) : base(dbContext)
        {
            //_dbContext = dbContext;
        }

        //private void Test(Func<Product, bool> filtre)
        //{

        //}

        //private void Deneme() //Lambda da birden fazla satır için örnek
        //{
        //    Test(p =>
        //    {
        //        int a = 5;
        //        return p.CategoryId == 5;
        //    });

        //}

        //public List<Product> GetByCategory(int categoryId)
        //{
        //    return _dbContext.Set<Product>().Where(p => p.CategoryId == categoryId).ToList(); //Lambda Expression
        //}

        //private DbContext _dbContext; // default da da private zaten.

        //public ProductDal(DbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public void Delete(Product entity)
        //{
        //    //using (var context = new NorthwindContext())
        //    //{
        //    //    context.Products.Remove(entity);
        //    //    context.SaveChanges();
        //    //}

        //    _dbContext.Set<Product>().Remove(entity);
        //    _dbContext.SaveChanges();
        //}

        //public List<Product> Getall()
        //{
        //    ////using li kullanımın adı disposable
        //    //using (var context = new NorthwindContext())
        //    //{
        //    //    return context.Products.ToList();
        //    //}

        //    return _dbContext.Set<Product>().ToList();
        //}

        //public List<Product> GetByCategory(int categoryId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Product Insert(Product entity)
        //{
        //    //using (var context = new NorthwindContext())
        //    //{
        //    //    context.Products.Add(entity);
        //    //    context.SaveChanges();

        //    //    return entity;
        //    //}

        //    _dbContext.Set<Product>().Add(entity);
        //    _dbContext.SaveChanges();

        //    return entity;
        //}

        //public Product Update(Product entity)
        //{
        //    //using (var context = new NorthwindContext())
        //    //{
        //    //    DbEntityEntry entry = context.Entry(entity);
        //    //    entry.State = System.Data.Entity.EntityState.Modified;

        //    //    context.SaveChanges();

        //    //    return entity;
        //    //}

        //    DbEntityEntry entry = _dbContext.Entry(entity);
        //    entry.State = System.Data.Entity.EntityState.Modified;

        //    _dbContext.SaveChanges();

        //    return entity;
        //}

    }
}
