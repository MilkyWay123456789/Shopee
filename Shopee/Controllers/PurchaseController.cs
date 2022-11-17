using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Controllers
{
    public class PurchaseController : Controller
    {
        ShopeeEntities db=new ShopeeEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(Guid ProductId, Guid MemberId)
        {
            var item=db.Purchases.Where(p=>p.ProductId==ProductId && p.MemberId==MemberId).FirstOrDefault(); 
            if(item==null)
            {
                db.Purchases.Add(new Purchase
                {
                    Id=Guid.NewGuid(),
                    ProductId=ProductId,
                    MemberId=MemberId,
                    Day=DateTime.Today,
                });
            }
            else
            {
                db.Purchases.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Purchase");
        }
    }
}