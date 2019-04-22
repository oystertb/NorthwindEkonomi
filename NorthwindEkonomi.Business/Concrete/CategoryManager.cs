using EkonomiCore.CrossCuttingConcern.Caching;
using NorthwindEkonomi.Business.Abstract;
using NorthwindEkonomi.DataAccess.Abstract;
using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        ICacheService _cacheService;
    
        public CategoryManager(ICategoryDal categoryDal, ICacheService cacheService)
        {
            _categoryDal = categoryDal;
            _cacheService = cacheService;
        }

        public List<Category> GetAll()
        {
            ////önce git cache e bak diycez.
            //if (_cacheService.IsExist("unique_key"))
            //    return _cacheService.Get<List<Category>>("unique_key");

            //var data = _categoryDal.GetAll();
            //_cacheService.Add("unique_key", data);

            //return data;

            return _cacheService.Cache("unique_key", () => _categoryDal.GetAll());
        }
    }
}
