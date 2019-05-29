using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 趣车网.Models;

namespace 趣车网.Controllers
{
    public class RegisterController : Controller
    {
        private CarEntities FEContext = new CarEntities();
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userName, string password,string sex)
        {
            UserInfo user = new UserInfo()
            {
                UserName = userName,
                UserPwd = password,
                UserSex=sex,
            };
            FEContext.UserInfo.Add(user);
            FEContext.SaveChanges();
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }
}