//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using DeluxeMobler.Models;

//namespace DeluxeMobler.Controllers
//{
//    public class SingleItemController : Controller
//    {
//        public List<Furniture> furniturelist = List.CreateList();
//        public UserInfo userinfo;
//        // GET: SingleItem
//        public ActionResult SingleItem()
//        {
//            if (Session["UserID"] is int)
//            {
//                userinfo = UserInfo.GetUserInfo((int)Session["UserID"]);
//            }
//            else
//            {
//                return RedirectToAction("SingleItem", "SingleItem");
//            }

//            return View(VM);
//        }
//    }
//}