using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        ShopeeEntities db = new ShopeeEntities();
        public Administrator member;
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           if(Session["Administrator"]==null && filterContext.RouteData.Values["controller"].ToString()!="Member")
            {
                filterContext.Result = new RedirectResult("/Admin/Member/Login");
            }
            else
            {
                member = (Administrator)Session["Administrator"];
            }
            base.OnActionExecuted(filterContext);
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotCredential()
        {
            return View();
        }
    }
}