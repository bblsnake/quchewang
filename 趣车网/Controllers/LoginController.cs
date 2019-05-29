using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 趣车网.Models;

namespace 趣车网.Controllers
{
    public class LoginController : Controller
    {
        private CarEntities CE = new CarEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string UserName, string password)
        {
            UserInfo ui = CE.UserInfo.Where(e => (e.UserName == UserName && e.UserPwd == password)).FirstOrDefault();
            if (ui != null)
            {
                Session["user"] = ui;
                return RedirectToRoute(new { controller = "Main", action = "Index" });
            }
            else
            {
                return View();
            }
        }

        public PartialViewResult summery()
        {
            return PartialView(User);
        }

        public RedirectToRouteResult LoginOut()
        {
            Session["user"] = null;
            return RedirectToRoute(new { controller = "Main", action = "Index" });
        }
    }
    }
