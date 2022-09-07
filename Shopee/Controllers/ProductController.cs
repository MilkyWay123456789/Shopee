using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Controllers
{
    public class ProductController : Controller
    {
        ShopeeEntities db=new ShopeeEntities();
        public ActionResult Index(Guid CategoryId)
        {
            var item=db.Products.Where(p=>p.CategoryId==CategoryId).ToList();
            return View(item);
        }
    }
}