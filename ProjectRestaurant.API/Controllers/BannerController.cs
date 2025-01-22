using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.BannerDTO;

namespace ProjectRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpPost("AddBanner")]
        public async Task<IActionResult> AddBanner(BannerDTORequest bannerDTOAddRequest)
        {
            var result = await _bannerService.AddAsync(bannerDTOAddRequest);
            return Ok(result);
        }

        [HttpPost("GetBanners")]
        public async Task<IActionResult> GetBanners(BannerDTORequest bannerDTOAddRequest)
        {
            var result = await _bannerService.GetAllAsync(bannerDTOAddRequest);
            return Ok(result);
        }

        [HttpGet("GetBanner/{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var result = await _bannerService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("UpdateBanner")]
        public async Task<IActionResult> UpdateBanner(BannerDTOUpdateRequest bannerDTORequest)
        {
            var result = await _bannerService.UpdateAsync(bannerDTORequest);
            return Ok(result);
        }

        [HttpPost("DeleteBanner")]
        public async Task<IActionResult> DeleteBanner(BannerDTOUpdateRequest bannerDTOUpdateRequest)
        {
            var result = await _bannerService.DeleteAsync(bannerDTOUpdateRequest);
            return Ok(result);
        }
    }
}
