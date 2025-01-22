using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.SpecialRecipeDTO;

namespace ProjectRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialRecipeController : ControllerBase
    {
        private readonly ISpecialRecipeService _specialRecipeService;

        public SpecialRecipeController(ISpecialRecipeService specialRecipeService)
        {
            _specialRecipeService = specialRecipeService;
        }

        [HttpPost("AddSpecialRecipe")]
        public async Task<IActionResult> AddSpecialRecipe(SpecialRecipeDTORequest specialRecipeDTORequest)
        {
            var result = await _specialRecipeService.AddAsync(specialRecipeDTORequest);
            return Ok(result);
        }

        [HttpPost("GetSpecialRecipes")]
        public async Task<IActionResult> GetSpecialRecipes(SpecialRecipeDTORequest specialRecipeDTORequest)
        {
            var result = await _specialRecipeService.GetAllAsync(specialRecipeDTORequest);
            return Ok(result);
        }

        [HttpGet("GetSpecialRecipe/{id}")]
        public async Task<IActionResult> GetSpecialRecipe(int id)
        {
            var result = await _specialRecipeService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("UpdateSpecialRecipe")]
        public async Task<IActionResult> UpdateSpecialRecipe(SpecialRecipeDTOUpdateRequest specialRecipeDTOUpdateRequest)
        {
            var result = await _specialRecipeService.UpdateAsync(specialRecipeDTOUpdateRequest);
            return Ok(result);
        }

        [HttpPost("DeleteSpecialRecipe")]
        public async Task<IActionResult> DeleteSpecialRecipe(SpecialRecipeDTOUpdateRequest specialRecipeDTOUpdateRequest)
        {
            var result = await _specialRecipeService.DeleteAsync(specialRecipeDTOUpdateRequest);
            return Ok(result);
        }
    }
}
