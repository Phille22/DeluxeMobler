using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeluxeMobler.Models;


//Controllern som hanterar inloggningen
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

                var CurrentUser = UserInfo.GetUserInfo(name); //Hämta användarinfo
                if(CurrentUser != null && CurrentUser.Password == password) //Kontrollera om uppgifterna stämmer överens med registrerade användare
                {
                    Session["UserID"] = CurrentUser.Id;
                    return RedirectToAction("Index", "Home"); //Gå till startsidan vid lyckad inloggning
                }
            }
            return View();
        }
    }
}