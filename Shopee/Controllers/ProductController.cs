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
        public ActionResult Index(Guid? CategoryId, string Keyword = "", int Page = 1)
        {
            var item=db.Products.ToList();
            if(CategoryId!=null)
            {
                item = item.Where(p => p.CategoryId == CategoryId).ToList();
            }
            else
            {
                if(Keyword!="")
                {
                    item = item.Where(p => p.Name == Keyword).ToList();
                }
            }
            var ItemPerPage = 2;
            var TotalPage = item.Count / ItemPerPage + (item.Count % ItemPerPage > 0 ? 1 : 0);
            ViewBag.TotalPage = TotalPage;
            item = item.Skip((Page - 1) * ItemPerPage).Take(ItemPerPage).ToList();
            return View(item);
        }
    }
}