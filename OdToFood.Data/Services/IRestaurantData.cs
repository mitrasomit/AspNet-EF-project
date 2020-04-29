using OdToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllData();
        Restaurant GetDetails(int id);
        void AddData(Restaurant restaurant);
        void UpdateDetails(Restaurant restaurant);
        void Delete(int id);
    }
}
