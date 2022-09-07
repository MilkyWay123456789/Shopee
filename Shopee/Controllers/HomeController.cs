using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Controllers
{
    public class HomeController : Controller
    {
        ShopeeEntities db = new ShopeeEntities();
        public ActionResult Index()
        {
            var product = db.Products.ToList();
            ViewBag.Product = product;
            return View();
        }
        public ActionResult Details(Guid Id)
        {
            return View(db.Products.Find(Id));
        }
    }
}