using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeluxeMobler.Models;

namespace DeluxeMobler.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            if(HttpContext.Request.RequestType == "POST")
            {
                var name = Request.Form["name"];
                var password = Request.Form["password"];

                var CurrentUser = UserInfo.GetUserInfo(name);
                if(CurrentUser != null && CurrentUser.Password == password)
                {
                    Session["UserID"] = CurrentUser.Id;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}