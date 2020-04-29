using OdToFood.Data.Models;
using OdToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ToFood.Web.API
{
    public class RestaurantController : ApiController
    {
        IRestaurantData _dbData;
        public RestaurantController(IRestaurantData restaurantData)
        {
            _dbData = restaurantData;
        }
        public IEnumerable<Restaurant> GetRestraData()
        {
            var model = _dbData.GetAllData();
            return model;
        }
    }
}
