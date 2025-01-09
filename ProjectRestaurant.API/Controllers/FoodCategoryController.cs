using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.FoodCategoryDTO;

namespace ProjectRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoryController : ControllerBase
    {
        private readonly IFoodCategoryService _foodCategoryService;

        public FoodCategoryController(IFoodCategoryService foodCategoryService)
        {
            _foodCategoryService = foodCategoryService;
        }

        [HttpPost("AddFoodCategory")]
        public async Task<IActionResult> AddFoodCategory(FoodCategoryDTORequest foodCategoryDTOAddRequest)
        {
            var result = await _foodCategoryService.AddAsync(foodCategoryDTOAddRequest);
            return Ok(result);
        }

        [HttpPost("GetFoodCategories")]
        public async Task<IActionResult> GetFoodCategories(FoodCategoryDTORequest foodCategoryDTOAddRequest)
        {
            var result = await _foodCategoryService.GetAllAsync(foodCategoryDTOAddRequest);
            return Ok(result);
        }

        [HttpGet("GetFoodCategory/{id}")]
        public async Task<IActionResult> GetFoodCategory(int id)
        {
            var result = await _foodCategoryService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("UpdateFoodCategory")]
        public async Task<IActionResult> UpdateFoodCategory(FoodCategoryDTOUpdateRequest foodCategoryDTORequest)
        {
            var result = await _foodCategoryService.UpdateAsync(foodCategoryDTORequest);
            return Ok(result);
        }

        [HttpPost("DeleteFoodCategory")]
        public async Task<IActionResult> DeleteFoodCategory(int id)
        {
            var result = await _foodCategoryService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
