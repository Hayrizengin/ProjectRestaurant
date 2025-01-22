using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.AboutDTO;

namespace ProjectRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }


        [HttpPost("AddAbout")]
        public async Task<IActionResult> AddAbout(AboutDTORequest aboutDTOAddRequest)
        {
            var result = await _aboutService.AddAsync(aboutDTOAddRequest);
            return Ok(result);
        }

        [HttpPost("GetAbouts")]
        public async Task<IActionResult> GetAbouts(AboutDTORequest aboutDTOAddRequest)
        {
            var result = await _aboutService.GetAllAsync(aboutDTOAddRequest);
            return Ok(result);
        }

        [HttpGet("GetAbout/{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var result = await _aboutService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("UpdateAbout")]
        public async Task<IActionResult> UpdateAbout(AboutDTOUpdateRequest aboutDTORequest)
        {
            var result = await _aboutService.UpdateAsync(aboutDTORequest);
            return Ok(result);
        }

        [HttpPost("DeleteAbout")]
        public async Task<IActionResult> DeleteAbout(AboutDTOUpdateRequest aboutDTOUpdateRequest)
        {
            var result = await _aboutService.DeleteAsync(aboutDTOUpdateRequest);
            return Ok(result);
        }

    }
}
