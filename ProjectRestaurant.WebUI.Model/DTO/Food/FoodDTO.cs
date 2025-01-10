using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.WebUI.Model.DTO.Food
{
    public class FoodDTO
    {
        //Update
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.Empty;

        //Request
        public string Name { get; set; } = "string";
        public decimal Price { get; set; } = 0;
        public string ImageUrl { get; set; } = "string";
        public int FoodCategoryId { get; set; } = 0; 

        //Response
        public string FoodCategoryName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
