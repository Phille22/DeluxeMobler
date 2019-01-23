using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeluxeMobler.Models;

//Huvudkontrollern

namespace DeluxeMobler.Controllers
{
    public class HomeController : Controller
    {
        public List<Furniture> furniturelist = Furniture.GetData(); //Hämta listan
        public UserInfo userinfo; 
        // GET: Home
        public ActionResult Index() //Action för huvudsidan
        {
            furniturelist.Sort((x, y) => string.Compare(y.NumberOfViews.ToString(), x.NumberOfViews.ToString())); //Sortera listan efter antal visningar
            if (Session["UserID"]is int)
            {
                userinfo = UserInfo.GetUserInfo((int)Session["UserID"]); //Hämta användarinfo
                if (userinfo.ViewList == null)
                {
                    userinfo.ViewList = new List<UserInfo.Viewed>(); //Skapa en lista där användarens visningar per objekt hamnar
                    foreach (Furniture furniture2 in furniturelist)
                    {
                        userinfo.ViewList.Add(new UserInfo.Viewed { id = furniture2.Id, nr = 0 });
                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

            ViewModel VM = ViewModel.Viewmodel(furniturelist, userinfo, 0);
            return View(VM);
        }

        //Action vid visning av enskilda objekt
        public ActionResult Link(int id)
        {
            foreach (Furniture furniture in furniturelist)
            {
                if(furniture.Id == id)
                {
                    furniture.NumberOfViews++; //Om id matchar, öka motsvarande möbels visningar med 1
                    Furniture.SaveData(furniturelist); //Spara
                    userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
                        foreach (UserInfo.Viewed view in userinfo.ViewList)
                        {
                            if (view.id == id)
                            view.nr++; //Öka antal visningar för möbeln för den inloggade användaren
                        }
                    UserInfo.SaveUserInfo(userinfo); //Spara användarinfo
                }
            }
            userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
            ViewModel VM = ViewModel.Viewmodel(furniturelist, userinfo, id);
            return View(VM);
        }
        //Action för att visa möbler av en viss kategori (Kan säkerligen slås ihop)
        public ActionResult Table()
        {
            furniturelist.Sort((x, y) => string.Compare(y.NumberOfViews.ToString(), x.NumberOfViews.ToString()));
            userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
            ViewModel VM = ViewModel.Viewmodel(furniturelist, userinfo, 0);
            return View(VM);
        }
        public ActionResult Bed()
        {
            furniturelist.Sort((x, y) => string.Compare(y.NumberOfViews.ToString(), x.NumberOfViews.ToString()));
            userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
            ViewModel VM = ViewModel.Viewmodel(furniturelist, userinfo, 0);
            return View(VM);
        }
    }
}