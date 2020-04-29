using OdToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdToFood.Data.Services
{
    public class InMemory_RestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemory_RestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Ezikio Pizza", Cuisine = CuisineType.Intalian },
                new Restaurant { Id = 2, Name = "Andre's c'Ulazo eat", Cuisine = CuisineType.Europian },
                new Restaurant { Id = 3, Name = "Butter Masala", Cuisine = CuisineType.Indian }
            };
        }

        public void AddData(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id=restaurants.Max(r => r.Id) + 1;
        }

        public void Delete(int id)
        {
            var resp = GetDetails(id);
            if (resp != null)
            {
                restaurants.Remove(resp);
            }
            
        }

        public IEnumerable<Restaurant> GetAllData()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetDetails(int id)
        {
            return restaurants.FirstOrDefault(r=>r.Id==id);
        }

        public void UpdateDetails(Restaurant restaurant)
        {
            var existing = GetDetails(restaurant.Id);
            if (existing !=null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
