using EkonomiCore.Aspects.Caching;
using EkonomiCore.Aspects.ExceptionHandling;
using EkonomiCore.CrossCuttingConcern.Caching;
using EkonomiCore.CrossCuttingConcern.Caching.MemoryCache;
using EkonomiCore.CrossCuttingConcern.ExceptionHandling;
using EkonomiCore.CrossCuttingConcern.Logging;
using EkonomiCore.CrossCuttingConcern.Logging.NLog;
using EkonomiCore.CrossCuttingConcern.Validation;
using NorthwindEkonomi.Business.Abstract;
using NorthwindEkonomi.Business.Aspects;
using NorthwindEkonomi.DataAccess.Abstract;
using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.Business.Concrete
{
    //[ErrorLogAspect(typeof(NLogService))] //Bu class için tüm methodlarda geçerli. Herhangi bir yerde hata oluşunca log alacak.
    //Bunu aynı zamanda diğer CategoryManager ve diğer benzeri classlarda da tek tek kullanmak yerine, bunu Business katmanındaki AssemblyInfo.cs dosyasına assembly olarak taşıdık.

    //[LogAspect(typeof(NLogService))]
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICacheService _cacheService;
        ILogService _logService;
        IValidationService<Product> _productValidationService;

        public ProductManager(IProductDal productDal, 
            ICacheService cacheService, 
            ILogService logService,
            IValidationService<Product> productValidationService)
        {
            _cacheService = cacheService;
            _productDal = productDal;
            _logService = logService;
            _productValidationService = productValidationService;
        }

        [NoLog] //Bu method da log alma demek için. Bunun için NoLogAttribute class oluşturduk ve LogAspectAttribute class da On Entry de bir kod yazdık.
        public List<Product> GetAll()
        {
            //return _productDal.GetAll();

            return _cacheService.Cache("unique_key2", () => _productDal.GetAll());
        }

        public List<Product> GetListByCategories(int categoryId)
        {
            var data = _productDal.GetList(t => t.CategoryId == categoryId);

            //var data = _productDal.GetByCategory(categoryId);

            //_logService.Info("GetListByCategoryId(" + categoryId + ")");
            _logService.Warn(data);

            return data;

            //return _cacheService.Cache("unique_key2", () => _productDal.GetByCategory(categoryId));
        }


        [MyCacheRemoveAspect("unique_key2")]
        public Product Insert(Product product)
        {
            //try
            //{
            //_logService.Info(product); //Artık bunun için de LogAspect yazdık. Burada yazmaya gerek yok

            _productValidationService.Validate(product);

                //İş kuralı 
                if (_productDal.IsAny(t => t.Name == product.Name))
                    throw new NotificationException("Aynı isimli ürün sistemde kayıtlı!");

                var addedProduct = _productDal.Insert(product);

                _cacheService.Remove("unique_key2"); //cache i temizledik ki ürün ekledikten sonra ana sayfaya yönlenince yeni eklenen ürünü göstersin.

                return addedProduct;
            //}
            //catch (ValidationException ex)
            //{
            //    throw;
            //}
            //catch (Exception e)
            //{
            //    //Validasyon hatalarını loglamak istemiyoruz. Eğer loglarsak veritabanı hemen dolar. 
            //    //O yüzden yukarıdaki catch de Validation Exception ı throw ettik ve oraya girmeyen Exceptionlar bu catch de veritabanına yazılacak.
                
            //    _logService.Error(product, e); //ErrorLogAspect yazdık bunun yerine

            //    throw;
            //}
        }
    }
}
