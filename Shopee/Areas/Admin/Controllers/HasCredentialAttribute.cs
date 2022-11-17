using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopee.Areas.Admin.Controllers
{
    public class HasCredentialAttribute:AuthorizeAttribute
    {
        public string RoleCode { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            List<string> RoleCodeList = GetRoleCodeByMember();
            if(RoleCode!=null && RoleCodeList.Contains(this.RoleCode))
            {
                return true;
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Admin/Home/NotCredential");
        }
        private List<string>GetRoleCodeByMember()
        {
            return (List<string>)HttpContext.Current.Session["Credential"];
        }
    }
}