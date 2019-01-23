using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeluxeMobler.Models;

namespace DeluxeMobler.Controllers
{
    public class CartController : Controller
    {
        public List<Furniture> furniturelist = Furniture.GetData(); //Hämta listan med möbler
        public UserInfo userinfo;
        // GET: Cart
        public ActionResult AddToCart(int id) //Action för att lägga till möbler i kundvagnen
        {
            foreach(Furniture furniture in furniturelist)
            {
                if (furniture.Id == id)
                {
                    furniture.InStock--; //Minska antal varor i lager med 1
                    Furniture.SaveData(furniturelist);
                    userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
                    if(userinfo.CartList == null)
                    {
                        userinfo.CartList = new List<UserInfo.Cart>(); //Skapa en ny kundvagn om det inte finns någon

                    }
                    userinfo.CartList.Add(new UserInfo.Cart { price = furniture.Price, name = furniture.Name }); //Lägg till en möbel i kundvagnen
                    UserInfo.SaveUserInfo(userinfo); //Spara användardata
                }

            }
            ViewModel VM = ViewModel.Viewmodel(furniturelist, userinfo, id);
            return RedirectToAction ("Link", "Home", new { Id = id }); //Stanna på samma sida
        }
        public ActionResult ShowCart() //Action när man visar kundvagnen
        {
            userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
            ViewModel VM = ViewModel.Viewmodel(furniturelist, userinfo, 1);
            return View(VM);
        }
        public ActionResult Buy() //Action när man "köper" möbler
        {
                userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
                ViewModel VM = ViewModel.Viewmodel(furniturelist, userinfo, 0);
                userinfo.CartList.Clear(); //Töm listan vid fulländat köp
                UserInfo.SaveUserInfo(userinfo); //Spara användardata
                return RedirectToAction("Index", "Home"); //Återgå till huvudsidan
        }
    } 
}