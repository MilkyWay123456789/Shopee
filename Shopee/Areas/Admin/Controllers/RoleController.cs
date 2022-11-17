using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        ShopeeEntities db=new ShopeeEntities();
        [HasCredential(RoleCode = "View-code")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetRole()
        {
            var role = db.Roles.Select(r => new { r.Id, r.Name, r.Code, r.GroupName }).ToList();
            return new JsonResult() { Data = role, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult Add()
        {
            return PartialView("Item", new Role());
        }
        public ActionResult Edit(Guid Id)
        {
            return PartialView("Item", db.Roles.Find(Id));
        }
        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            Guid Id = Guid.Parse(form["Id"]);
            Role item;
            if (Id == Guid.Empty)
            {
                item = new Role();
                item.Id = Guid.NewGuid();
                db.Roles.Add(item);
            }
            else
            {
                item = db.Roles.Find(Id);
            }
            item.Name = form["Name"];
            item.Code = form["RoleCode"];
            item.GroupName = form["GroupName"];
            db.SaveChanges();
            return RedirectToAction("Index", "Role");
        }
        public ActionResult Delete(Guid Id)
        {
            var item = db.Roles.Find(Id);
            if (item != null)
            {
                db.Roles.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Role");
        }
    }
}