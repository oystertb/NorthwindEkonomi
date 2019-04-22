using EkonomiCore.CrossCuttingConcern.Caching;
using EkonomiCore.CrossCuttingConcern.Caching.MemoryCache;
using EkonomiCore.CrossCuttingConcern.Logging;
using EkonomiCore.CrossCuttingConcern.Logging.NLog;
using EkonomiCore.CrossCuttingConcern.Validation;
using NorthwindEkonomi.Business.Abstract;
using NorthwindEkonomi.Business.Concrete;
using NorthwindEkonomi.Business.ValidationRules;
using NorthwindEkonomi.Business.ValidationRules.FluentValidation;
using NorthwindEkonomi.DataAccess.Abstract;
using NorthwindEkonomi.DataAccess.Concrete.EntityFramework;
using NorthwindEkonomi.DataAccess.Concrete.EntityFramework.Context;
using NorthwindEkonomi.Entities.Entity;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NorthwindEkonomi.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Kodu buradan alıp modifiye ettik: https://simpleinjector.readthedocs.io/en/latest/mvcintegration.html

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance: 
            //Buraları modifiye ettik. IOC containers
            container.Register<IProductService, ProductManager>(Lifestyle.Scoped); //uygulamanın lifescope u boyunca bu oluşturulan instance ı kullanır.
            container.Register<IProductDal, ProductDal>(Lifestyle.Scoped);
            container.Register<DbContext, NorthwindContext>(Lifestyle.Scoped);
            container.Register<ICategoryService, CategoryManager>(Lifestyle.Scoped);
            container.Register<ICategoryDal, CategoryDal>(Lifestyle.Scoped);
            container.Register<ICacheService, MemoryCacheService>(Lifestyle.Scoped);
            container.Register<ILogService, NLogService>(Lifestyle.Scoped);
            //container.Register<IValidationService<Product>, MyProductValidatorService>(Lifestyle.Scoped);
            //Validation kütüphanesi değişince yalnızca bu satırı güncellememiz yetti.
            container.Register<IValidationService<Product>, ProductValidationService>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
