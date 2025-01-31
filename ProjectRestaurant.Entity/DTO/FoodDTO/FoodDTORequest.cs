using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Entity.DTO.FoodDTO
{
    public class FoodDTORequest
    {
        public string Name { get; set; } = "string";
        public decimal Price { get; set; } = 0;
        public string ImageUrl { get; set; } = "string";
        public int FoodCategoryId { get; set; } = 0;
    }
}
