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
        public ActionResult Index(int Page=1)
        {
            var product = db.Products.ToList(); 
            var ItemPerPage = 10;
            var TotalPage = product.Count / ItemPerPage + (product.Count % ItemPerPage > 0 ? 1 : 0);
            ViewBag.TotalPage = TotalPage;
            product = product.Skip((Page - 1) * ItemPerPage).Take(ItemPerPage).ToList();
            return View(product);
        }
        public ActionResult PopularProduct(int Page=1)
        {
            var product = db.Products.OrderBy(p=>p.Sale).ToList();
            var ItemPerPage = 10;
            var TotalPage = product.Count / ItemPerPage + (product.Count % ItemPerPage > 0 ? 1 : 0);
            ViewBag.TotalPage = TotalPage;
            product = product.Skip((Page - 1) * ItemPerPage).Take(ItemPerPage).ToList();
            return View(product);
        }
        public ActionResult BoughtProduct(int Page = 1)
        {
            var product = db.Products.OrderBy(p => p.Bought).ToList();
            var ItemPerPage = 10;
            var TotalPage = product.Count / ItemPerPage + (product.Count % ItemPerPage > 0 ? 1 : 0);
            ViewBag.TotalPage = TotalPage;
            product = product.Skip((Page - 1) * ItemPerPage).Take(ItemPerPage).ToList();
            return View(product);
        }
        public ActionResult DescProduct(int Page = 1)
        {
            var product = db.Products.OrderByDescending(p => p.OldPrice).ToList();
            var ItemPerPage = 10;
            var TotalPage = product.Count / ItemPerPage + (product.Count % ItemPerPage > 0 ? 1 : 0);
            ViewBag.TotalPage = TotalPage;
            product = product.Skip((Page - 1) * ItemPerPage).Take(ItemPerPage).ToList();
            return View(product);
        }
        public ActionResult AscProduct(int Page = 1)
        {
            var product = db.Products.OrderBy(p => p.OldPrice).ToList();
            var ItemPerPage = 10;
            var TotalPage = product.Count / ItemPerPage + (product.Count % ItemPerPage > 0 ? 1 : 0);
            ViewBag.TotalPage = TotalPage;
            product = product.Skip((Page - 1) * ItemPerPage).Take(ItemPerPage).ToList();
            return View(product);
        }
        public ActionResult Details(Guid Id)
        {
            return View(db.Products.Find(Id));
        }
    }
}