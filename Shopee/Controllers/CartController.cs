using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;
namespace Shopee.Controllers
{
    public class CartController : Controller
    {
        ShopeeEntities db = new ShopeeEntities();
        public ActionResult Index(Guid ProductId)
        {
            var item = db.Products.Find(ProductId);
            return View(item);
        }
        public ActionResult Add(Guid ProductId, Guid MemberId)
        {
            var item = db.ProductOfMembers.Where(x => x.MemberId == MemberId && x.ProductId == ProductId).FirstOrDefault();
            if(item == null)
            {
                db.ProductOfMembers.Add(new ProductOfMember
                {
                    Id= Guid.NewGuid(),
                    ProductId = ProductId,
                    MemberId = MemberId
                });
            }
            else
            {
                db.ProductOfMembers.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Cart", new {ProductId = ProductId });
        }
        public ActionResult Delete(Guid ProductId)
        {
            var product = db.ProductOfMembers.Find(ProductId);
            if(product!=null)
            {
                db.ProductOfMembers.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}