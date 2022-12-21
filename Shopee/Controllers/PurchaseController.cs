using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopee.Models;

namespace Shopee.Controllers
{
    public class PurchaseController : Controller
    {
        ShopeeEntities db=new ShopeeEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Guid ProductId, Guid MemberId,int price,FormCollection req)
        {
            var item=db.Orders.Where(p=>p.ProductId==ProductId && p.MemberId==MemberId).FirstOrDefault(); 
            if(item==null)
            {
                db.Orders.Add(new Order
                {
                    Id=Guid.NewGuid(),
                    ProductId=ProductId,
                    MemberId=MemberId,
                    Day=DateTime.Today,
                    Email=req["Email"],
                    Address=req["Address"],
                    Phone=req["Phone"],
                    Name=req["Name"],
                    Status=false,
                });
                string content = System.IO.File.ReadAllText(Server.MapPath("~/content/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", req["Name"]);
                content = content.Replace("{{Phone}}", req["Phone"]);
                content = content.Replace("{{Email}}", req["Email"]);
                content = content.Replace("{{Address}}", req["Address"]);
                content = content.Replace("{{Total}}",price.ToString() );
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                // Để Gmail cho phép SmtpClient kết nối đến server SMTP của nó với xác thực 
                //là tài khoản gmail của bạn, bạn cần thiết lập tài khoản email của bạn như sau:
                //Vào địa chỉ https://myaccount.google.com/security  Ở menu trái chọn mục Bảo mật, sau đó tại mục Quyền truy cập 
                //của ứng dụng kém an toàn phải ở chế độ bật
                //  Đồng thời tài khoản Gmail cũng cần bật IMAP
                //Truy cập địa chỉ https://mail.google.com/mail/#settings/fwdandpop

                new MailHelper().SendMail(req["Email"], "Đơn hàng mới từ Shopee", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ Shopee", content);
            }
            else
            {
                db.Orders.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Purchase");
        }
    }
}