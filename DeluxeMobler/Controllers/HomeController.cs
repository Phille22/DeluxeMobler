using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeluxeMobler.Models;

namespace DeluxeMobler.Controllers
{
    public class HomeController : Controller
    {
        public List<Furniture> furniturelist = List.CreateList();
        public UserInfo userinfo;
        // GET: Home
        public ActionResult Index()
        {
            if (Session["UserID"]is int)
            {
                userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

            ViewModel VM = ViewModel.viewModel(furniturelist, userinfo);
            return View(VM);
            //return View(furniturelist);
        }
    }
}