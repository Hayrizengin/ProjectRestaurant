using ProjectRestaurant.Entity.DTO.FoodCategoryDTO;
using ProjectRestaurant.Entity.DTO.FoodDTO;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Models
{
    public class FoodViewModel
    {
        public List<FoodDTOResponse> Foods { get; set; }
        public List<FoodCategoryDTOResponse> FoodCategories { get; set; }
    }
}
