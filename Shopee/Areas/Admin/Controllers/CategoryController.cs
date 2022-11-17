using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ShopeeEntities db = new ShopeeEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View("Item", new Category());
        }
        public ActionResult Edit(Guid Id)
        {
            return View("Item", db.Categories.Find(Id));
        }
        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            Guid Id = Guid.Parse(form["Id"]);
            Category item;
            if (Id == Guid.Empty)
            {
                item = new Category();
                item.Id = Guid.NewGuid();
                db.Categories.Add(item);
            }
            else
            {
                item = db.Categories.Find(Id);
            }
            item.Name = form["Name"];
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Delete(Guid Id)
        {
            try
            {
                var item = db.Categories.Find(Id);
                db.Categories.Remove(item);
                db.SaveChanges();
            }
            catch { }
            return RedirectToAction("Index", "Category");
        }
        public ActionResult GetCategory()
        {
            var item = db.Categories.OrderBy(c => c.Name).Select(c => new { c.Id, c.Name }).ToList();
            return new JsonResult() { Data = item, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}