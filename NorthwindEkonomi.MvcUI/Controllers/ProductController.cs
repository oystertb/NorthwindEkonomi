using NorthwindEkonomi.Business.Abstract;
using NorthwindEkonomi.Entities.Entity;
using NorthwindEkonomi.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindEkonomi.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        //Dependency Injection
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        } //Dependency Injection finished

        public ActionResult Index(int? categoryId) //nullable
        {
            var products = categoryId.HasValue
                ? _productService.GetListByCategories(categoryId.Value)
                : _productService.GetAll();

            var model = new ProductIndexViewModel
            {
                Products = products
            };

            return View(model);
        }

        public ActionResult Insert()
        {
            //http://localhost:49232/Product/Insert bu şekilde bu Action çalışıyor.
            var product = new Product
            {
                Name = "Patates",
                CategoryId=1,
                Description = "yok",
                UnitPrice = 7
            };

            _productService.Insert(product);

            return RedirectToAction("Index"); //İşlem başarılıysa ana sayfaya yönlendirme işlemi
        }
    }
}