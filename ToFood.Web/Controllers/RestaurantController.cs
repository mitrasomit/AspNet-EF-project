using OdToFood.Data.Models;
using OdToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToFood.Web.Controllers
{
    public class RestaurantController : Controller
    {
        IRestaurantData _dbData;
        public RestaurantController(IRestaurantData restaurantData)
        {
            this._dbData = restaurantData;
        }
        // GET: Restaurant
        public ActionResult Index()
        {
            var model = _dbData.GetAllData();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = _dbData.GetDetails(id);
            if (model == null)
            {
                View("ErrorPage");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _dbData.AddData(restaurant);
                TempData["Msg"] = "Data saved successfully";
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();  
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _dbData.GetDetails(id);
            if (model==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _dbData.UpdateDetails(restaurant);
                return RedirectToAction("Details",new {id= restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var resp = Details(id);
            if (resp == null)
            {
                return View("ErrorPage");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id ,FormCollection form)
        {
           _dbData.Delete(id); 
            return RedirectToAction("Index");
        }
    }
}