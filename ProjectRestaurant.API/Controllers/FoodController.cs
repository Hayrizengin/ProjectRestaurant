using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.FoodDTO;

namespace ProjectRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpPost("AddFood")]
        public async Task<IActionResult> AddFood(FoodDTORequest foodDTOAddRequest)
        {
            var result = await _foodService.AddAsync(foodDTOAddRequest);
            return Ok(result);
        }

        [HttpPost("GetFoods")]
        public async Task<IActionResult> GetFoods(FoodDTORequest foodDTOAddRequest)
        {
            var result = await _foodService.GetAllAsync(foodDTOAddRequest);
            return Ok(result);
        }

        [HttpGet("GetFood/{id}")]
        public async Task<IActionResult> GetFood(int id)
        {
            var result = await _foodService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("UpdateFood")]
        public async Task<IActionResult> UpdateFood(FoodDTOUpdateRequest foodDTORequest)
        {
            var result = await _foodService.UpdateAsync(foodDTORequest);
            return Ok(result);
        }

        [HttpPost("DeleteFood")]
        public async Task<IActionResult> DeleteFood(FoodDTOUpdateRequest foodDTOUpdateRequest)
        {
            var result = await _foodService.DeleteAsync(foodDTOUpdateRequest);
            return Ok(result);
        }
    }
}
