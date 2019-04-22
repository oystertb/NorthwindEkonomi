using NorthwindEkonomi.Business.Abstract;
using NorthwindEkonomi.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindEkonomi.MvcUI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult List()
        {
            var categories = _categoryService.GetAll();

            var model = new CategoryListViewModel
            {
                Categories = categories
            };

            return PartialView(model); // return PartialView(model); bu şekilde de gönderilebilirdi.
        }
    }
}