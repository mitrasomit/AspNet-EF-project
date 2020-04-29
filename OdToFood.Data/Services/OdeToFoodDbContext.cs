using OdToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdToFood.Data.Services
{
   public class OdeToFoodDbContext :DbContext
    {
        public DbSet<Restaurant> Restaurants_Dcntx { get; set; }
    }
}
