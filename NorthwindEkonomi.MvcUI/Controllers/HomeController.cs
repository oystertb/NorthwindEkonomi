using NorthwindEkonomi.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindEkonomi.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Ekonomi Bakanlığı";
        }

        public string Test(string ad)
        {
            return "Merhaba" + ad;
        }

        public ActionResult Deneme()
        {
            return null;
        }

        public ActionResult XmlResult()
        {
            return Content(@"<note>
                            <to>Tove</to>
                            </note>","application/xml");
        }

        public ActionResult JsonResult()
        {
            return Json(new { ad = "Selen", soyad = "Ozek"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewResult()
        {
            return View();
        }

        public ActionResult Ornek()
        {
            return View("ViewResult");
        }

        public ActionResult Demo()
        {
            var isimler = new List<string> { "selen", "gülçin", "murat", "salih" };
            var sayilar = new List<int> { 100, 200, 300 };

            //Controllerden View e bir değişken iletebiliyoruz. Bu sebeple model kullanıp göndermek en iyi çözüm. Best practice
            var model = new HomeDemoViewModel
            {
                Isimler = isimler,
                Sayilar = sayilar
            };

            return View(model);
        }
    }
}