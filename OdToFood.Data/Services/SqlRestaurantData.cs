using OdToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext odeTo;
        public SqlRestaurantData(OdeToFoodDbContext odeToFoodDbContext)
        {
            this.odeTo = odeToFoodDbContext;
        }
        public void AddData(Restaurant restaurant)
        {
            odeTo.Restaurants_Dcntx.Add(restaurant);
            odeTo.SaveChanges();
        }

        public void Delete(int id)
        {           
            var resp = odeTo.Restaurants_Dcntx.Find(id);
            odeTo.Restaurants_Dcntx.Remove(resp);
            odeTo.SaveChanges();
        }

        public IEnumerable<Restaurant> GetAllData()
        {
            return from db in odeTo.Restaurants_Dcntx orderby db.Name select db; //select * from all
        }

        public Restaurant GetDetails(int id)
        {
            return odeTo.Restaurants_Dcntx.FirstOrDefault(db => db.Id == id);
        }

        public void UpdateDetails(Restaurant restaurant)
        {
            var entry = odeTo.Entry(restaurant);
            entry.State = System.Data.Entity.EntityState.Modified;
            odeTo.SaveChanges();
        }
    }
}
