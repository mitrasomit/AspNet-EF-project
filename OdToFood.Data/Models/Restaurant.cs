using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdToFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name= "Type of Cuisine")]
        public CuisineType Cuisine { get; set; }
    }
}
