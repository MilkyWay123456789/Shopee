using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Areas.Admin.Controllers
{
    public class GroupController : Controller
    {
        ShopeeEntities db = new ShopeeEntities();
        [HasCredential(RoleCode = "View-group")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return PartialView("Item", new Group());
        }
        public ActionResult Edit(Guid Id)
        {
            return PartialView("Item", db.Groups.Find(Id));
        }
        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            Guid Id = Guid.Parse(form["Id"]);
            Group item;
            if (Id == Guid.Empty)
            {
                item = new Group();
                item.Id = Guid.NewGuid();
                db.Groups.Add(item);
            }
            else
            {
                item = db.Groups.Find(Id);
            }
            item.Name = form["Name"];
            db.SaveChanges();
            return RedirectToAction("Index", "Group");
        }
        public ActionResult Delete(Guid Id)
        {
            var item = db.Groups.Find(Id);
            if (item != null)
            {
                db.Groups.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Group");
        }
        public ActionResult GetGroup()
        {
            var item = db.Groups.OrderBy(a => a.Name).Select(a => new { a.Name, a.Id }).ToList();
            return new JsonResult() { Data = item, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult Credential(Guid Id)
        {
            var rolelist = db.Roles.OrderBy(r => r.GroupName).ToList();
            ViewBag.rolelist = rolelist;
            var group = db.Groups.Find(Id);
            return View(group);
        }
        public async Task<ActionResult> UpdateRole(Guid GroupId,Guid RoleId)
        {
            var item = db.Credentials.Where(c => c.GroupId == GroupId && c.RoleId == RoleId).FirstOrDefault();
            if(item==null)
            {
                db.Credentials.Add(new Models.Credential
                {
                    Id = Guid.NewGuid(),
                    GroupId=GroupId,
                    RoleId=RoleId,
                });
            }
            else
            {
                db.Credentials.Remove(item);
            }
            await db.SaveChangesAsync();
            return new JsonResult() { Data=1, JsonRequestBehavior=JsonRequestBehavior.AllowGet };
        }
    }
}