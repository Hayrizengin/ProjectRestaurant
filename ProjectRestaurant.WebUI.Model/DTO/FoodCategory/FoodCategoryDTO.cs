using ProjectRestaurant.WebUI.Model.DTO.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.WebUI.Model.DTO.FoodCategory
{
    public class FoodCategoryDTO
    {
        //Update
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.Empty;

        //Request
        public string Name { get; set; } = "string";

        //Response
        public List<FoodDTO> Foods { get; set; } = new List<FoodDTO>();
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
