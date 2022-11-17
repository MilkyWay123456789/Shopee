using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Areas.Admin.Controllers
{
    public class MemberController : Controller
    {
        ShopeeEntities db = new ShopeeEntities();
        [HasCredential(RoleCode ="View-member")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            ViewBag.GroupId = new SelectList(db.Groups.OrderBy(g => g.Name).ToList(), "Id", "Name");
            return View("Item", new Administrator());
        }
        public ActionResult Edit(Guid Id)
        {
            ViewBag.GroupId = new SelectList(db.Groups.OrderBy(g => g.Name).ToList(), "Id", "Name");
            return View("Item", db.Administrators.Find(Id));
        }
        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            Guid Id = Guid.Parse(form["Id"]);
            Administrator item;
            if (Id == Guid.Empty)
            {
                item = new Administrator();
                item.Id = Guid.NewGuid();
                db.Administrators.Add(item);
            }
            else
            {
                item = db.Administrators.Find(Id);
            }
            item.UserName = form["Name"];
            if (form["GroupId"] != "")
            {
                item.GroupId = Guid.Parse(form["GroupId"]);
            }
            if (form["Password"] != "")
            {
                item.Password = form["Password"];
            }
            item.Email = form["Email"];
            HttpPostedFileBase file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                string path = "/assets/img/" + file.FileName;
                file.SaveAs(Server.MapPath(path));
                item.Picture = path;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Member");
        }
        public ActionResult Delete(Guid Id)
        {
            try
            {
                var item = db.Administrators.Find(Id);
                db.Administrators.Remove(item);
                db.SaveChanges();
            }
            catch { }
            return RedirectToAction("Index", "Member");
        }
        public ActionResult GetMember()
        {
            var items = db.Administrators.OrderBy(m => m.UserName).Select(m => new { m.UserName, GroupName = m.Group.Name, m.Id }).ToList();
            return new JsonResult() { Data = items, MaxJsonLength = Int32.MaxValue, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(FormCollection form)
        {
            string LoginName = form["Name"], Password = form["Password"];
            var item = db.Administrators.Where(m => m.UserName == LoginName && m.Password == Password).FirstOrDefault();
            if (item == null)
            {
                return RedirectToAction("Login", "Member");
            }
            Session["Administrator"] = item;
            Session["Credential"] = new CredentialController().GetRoleCodeList(item);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session["Administrator"] = null;
            return RedirectToAction("Login", "Member");
        }
    }
}