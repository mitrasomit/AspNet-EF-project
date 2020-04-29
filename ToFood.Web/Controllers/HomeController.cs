using OdToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData _db;
        public HomeController( IRestaurantData restaData)
        {
            _db = restaData;
        }
        public ActionResult Index()
        {
           var model = _db.GetAllData();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}