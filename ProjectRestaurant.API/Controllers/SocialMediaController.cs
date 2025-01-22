using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.SocialMediaDTO;

namespace ProjectRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpPost("AddSocialMedia")]
        public async Task<IActionResult> AddSocialMedia(SocialMediaDTORequest socialMediaDTORequest)
        {
            var result = await _socialMediaService.AddAsync(socialMediaDTORequest);
            return Ok(result);
        }

        [HttpPost("GetSocialMedias")]
        public async Task<IActionResult> GetSocialMedias(SocialMediaDTORequest socialMediaDTORequest)
        {
            var result = await _socialMediaService.GetAllAsync(socialMediaDTORequest);
            return Ok(result);
        }

        [HttpGet("GetSocialMedia/{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var result = await _socialMediaService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("UpdateSocialMedia")]
        public async Task<IActionResult> UpdateSocialMedia(SocialMediaDTOUpdateRequest socialMediaDTOUpdateRequest)
        {
            var result = await _socialMediaService.UpdateAsync(socialMediaDTOUpdateRequest);
            return Ok(result);
        }

        [HttpPost("DeleteSocialMedia")]
        public async Task<IActionResult> DeleteSocialMedia(SocialMediaDTOUpdateRequest socialMediaDTOUpdateRequest)
        {
            var result = await _socialMediaService.DeleteAsync(socialMediaDTOUpdateRequest);
            return Ok(result);
        }
    }
}
