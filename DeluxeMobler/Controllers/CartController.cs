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
        public List<Furniture> furniturelist = Furniture.GetData();
        public UserInfo userinfo;
        // GET: Cart
        public ActionResult AddToCart(int id)
        {
            foreach(Furniture furniture in furniturelist)
            {
                if(furniture.id == id)
                {
                    userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
                    if(userinfo.CartList == null)
                    {
                        userinfo.CartList = new List<UserInfo.Cart>();

                    }
                    userinfo.CartList.Add(new UserInfo.Cart { price = furniture.Price, name = furniture.Name });
                    UserInfo.SaveUserInfo(userinfo);
                }

            }
            ViewModel VM = ViewModel.viewModel(furniturelist, userinfo, id);
            return RedirectToAction ("Link", "Home", new { Id = id });
        }
        public ActionResult ShowCart()
        {
            userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
            ViewModel VM = ViewModel.viewModel(furniturelist, userinfo, 1);
            return View(VM);
        }
        public ActionResult Buy()
        {
                userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
                ViewModel VM = ViewModel.viewModel(furniturelist, userinfo, 0);
                userinfo.CartList.Clear();
                UserInfo.SaveUserInfo(userinfo);
                return RedirectToAction("Index", "Home");
        }
    } 
}