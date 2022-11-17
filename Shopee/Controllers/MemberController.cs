using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Controllers
{
    public class MemberController : Controller
    {
        ShopeeEntities db=new ShopeeEntities();
        public ActionResult Index(Guid MemberId)
        {
            var member = db.Members.Find(MemberId);
            return View(member);
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string email = form["Email"], Password = MD5Hash(form["Password"]);
            var account=db.Members.Where(a=>a.Email==email && a.Password==Password).FirstOrDefault();
            if(account==null)
            {
                return RedirectToAction("Index", "Home");
            }
            Session["Members"]=account;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            string email = form["Email"];
            var account=db.Members.Where(a=>a.Email==email).FirstOrDefault();
            if(account!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            var member = (new Member()
            {
                Id=Guid.NewGuid(),
                Email=email,
                Password = MD5Hash(form["Password"]),
            });
            db.Members.Add(member);
            db.SaveChanges();
            Session["Members"] = member;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session["Members"] = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            Guid Id = Guid.Parse(form["Id"]);
            Member member = db.Members.Find(Id);
            member.Name=form["Name"];
            member.Email = form["Email"];
            member.Password = MD5Hash(form["Password"]);
            HttpPostedFileBase file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
               string path = "/assets/img/" + file.FileName;
               file.SaveAs(Server.MapPath(path));
               member.Picture = path;
            }
            Session["Members"] = member;
            db.SaveChanges();
            return RedirectToAction("Index", "Member", new { MemberId = Id });
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}