using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Areas.Admin.Controllers
{
    public class CredentialController : Controller
    {
        ShopeeEntities db=new ShopeeEntities();
        public ActionResult Index()
        {
            return View();
        }
        public List<string> GetRoleCodeList(Administrator member)
        {
            return db.Credentials.Where(c => c.GroupId == member.GroupId).Select(c => c.Role.Code).ToList();
        }
    }
}