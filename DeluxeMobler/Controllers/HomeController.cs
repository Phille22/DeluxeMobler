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
        public List<Furniture> furniturelist = Furniture.GetData();
        public UserInfo userinfo;
        // GET: Home
        public ActionResult Index()
        {
            furniturelist.Sort((x, y) => string.Compare(y.NumberOfViews.ToString(), x.NumberOfViews.ToString()));
            if (Session["UserID"]is int)
            {

                userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
                if (userinfo.ViewList == null)
                {
                    userinfo.ViewList = new List<UserInfo.Viewed>();
                    foreach (Furniture furniture2 in furniturelist)
                    {
                        userinfo.ViewList.Add(new UserInfo.Viewed { id = furniture2.id, nr = 0 });
                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

            ViewModel VM = ViewModel.viewModel(furniturelist, userinfo, 0);
            return View(VM);
        }

        public ActionResult Link(int id)
        {
            foreach (Furniture furniture in furniturelist)
            {
                if(furniture.id == id)
                {
                    furniture.NumberOfViews++;
                    Furniture.SaveData(furniturelist);
                    userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
                        foreach (UserInfo.Viewed view in userinfo.ViewList)
                        {
                            if (view.id == id)
                            view.nr++;
                        }
                    UserInfo.SaveUserInfo(userinfo);
                }
            }
            userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
            ViewModel VM = ViewModel.viewModel(furniturelist, userinfo, id);
            return View(VM);
        }
        public ActionResult Table()
        {
            userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
            ViewModel VM = ViewModel.viewModel(furniturelist, userinfo, 0);
            return View(VM);
        }
        public ActionResult Bed()
        {
            userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
            ViewModel VM = ViewModel.viewModel(furniturelist, userinfo, 0);
            return View(VM);
        }
    }
}