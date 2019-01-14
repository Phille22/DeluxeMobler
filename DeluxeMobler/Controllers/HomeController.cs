using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeluxeMobler.Controllers
{
    public class HomeController : Controller
    {
        public List<Models.Furniture> furniturelist = Models.List.CreateList();
        // GET: Home
        public ActionResult Index()
        {
            return View(furniturelist);
        }
    }
}