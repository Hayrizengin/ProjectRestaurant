using ProjectRestaurant.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.Poco
{
    public class FoodCategory: AuditableEntity
    {
        public FoodCategory()
        {
            Foods = new HashSet<Food>();
        }
        public string Name { get; set; }
        public virtual IEnumerable<Food> Foods { get; set; }

    }
}
