using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ShopeeEntities db = new ShopeeEntities();
        [HasCredential(RoleCode = "View-product")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(g => g.Name).ToList(), "Id", "Name");
            return View("Item", new Product());
        }
        public ActionResult Edit(Guid Id)
        {
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(g => g.Name).ToList(), "Id", "Name");
            return View("Item", db.Products.Find(Id));
        }
        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            Guid Id = Guid.Parse(form["Id"]);
            Product item;
            if (Id == Guid.Empty)
            {
                item = new Product();
                item.Id = Guid.NewGuid();
                db.Products.Add(item);
            }
            else
            {
                item = db.Products.Find(Id);
            }
            HttpPostedFileBase file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                string path = "/assets/img/" + file.FileName;
                file.SaveAs(Server.MapPath(path));
                item.Picture = path;
            }
            item.Name = form["Name"];
            item.OldPrice = int.Parse(form["OldPrice"]);
            item.NewPrice = int.Parse(form["NewPrice"]);
            item.Bought = int.Parse(form["Bought"]);
            item.Sale = int.Parse(form["Sale"]);
            item.CategoryId = Guid.Parse(form["CategoryId"]);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Delete(Guid Id)
        {
            var item = db.Products.Find(Id);
            if (item != null)
            {
                db.Products.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Product");
        }

        public ActionResult GetAllProduct()
        {
            var items = db.Products.OrderBy(a => a.Name).Select(b => new { b.Name,b.OldPrice, b.Id, Categories = b.Category.Name }).ToList();
            return new JsonResult() { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}