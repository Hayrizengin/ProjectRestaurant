using ProjectRestaurant.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.Poco
{
    public class Food: AuditableEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int FoodCategoryId { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }

    }
}
