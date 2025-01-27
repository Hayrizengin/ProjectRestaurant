using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Entity.DTO.AboutDTO;
using ProjectRestaurant.Entity.DTO.BannerDTO;
using ProjectRestaurant.WebUI.Areas.AdminPanel.Models;
using ProjectRestaurant.WebUI.Helper.APIHelper;
using ProjectRestaurant.WebUI.Helper.SessionHelper;
using System.Net;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BannerController : Controller
    {
        private readonly IApiService _apiService;

        public BannerController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("/Admin/Banner")]
        public async Task<IActionResult> Index()
        {
            var banners = await _apiService.SendRequestAsync<BannerDTORequest, List<BannerDTOResponse>>(new ApiRequest<BannerDTORequest>
            {
                Body = new BannerDTORequest(),
                Method = HttpMethod.Post,
                URL = "/api/Banner/GetBanners",
                //Token = SessionManager.loginDTOResponse.Token
            });

            BannerViewModel bannerViewModel = new BannerViewModel()
            {
                Banners = banners.Data
            };
            return View(bannerViewModel);
        }

        [HttpPost("/Banner/AddBanner")]
        public async Task<IActionResult> AddBanner(BannerDTORequest bannerDTORequest,IFormFile ImageUrl)
        {
            //Fotoğrafı base64 şekline çevirme
            string base64String = null;

            if (ImageUrl != null && ImageUrl.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await ImageUrl.CopyToAsync(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();
                    base64String = Convert.ToBase64String(fileBytes);
                }
                bannerDTORequest.ImageUrl = base64String;
            }

            ApiRequest<BannerDTORequest> request = new()
            {
                URL = "/api/Banner/AddBanner",
                Body = bannerDTORequest,
                Method = HttpMethod.Post,
                //Token =  SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestAsync<BannerDTORequest, BannerDTOResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["AddBannerError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","Banner");
            }
            else
            {
                ViewData["AddBannerSuccess"] = "Başarılı !";
                return RedirectToAction("Index","Banner");
            }
        }

        [HttpPost("/Banner/UpdateBanner")]
        public async Task<IActionResult> UpdateBanner(BannerDTOUpdateRequest bannerDTOUpdateRequest,IFormFile ImageUrl)
        {
            //Fotoğrafı base64 şekline çevirme
            string base64String = null;

            if (ImageUrl != null && ImageUrl.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await ImageUrl.CopyToAsync(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();
                    base64String = Convert.ToBase64String(fileBytes);
                }
                bannerDTOUpdateRequest.ImageUrl = base64String;
            }

            ApiRequest<BannerDTOUpdateRequest> request = new()
            {
                URL = "/api/Banner/UpdateBanner",
                Body = bannerDTOUpdateRequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<BannerDTOUpdateRequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["UpdateBannerError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","Banner");
            }
            else
            {
                ViewData["UpdateBannerSuccess"] = "Başarılı !";
                return RedirectToAction("Index","Banner");
            }

        }

        [HttpPost("/Banner/DeleteBanner")]
        public async Task<IActionResult> DeleteBanner(BannerDTOUpdateRequest bannerDTOUpdateRequest,IFormFile ImageUrl)
        {
            ApiRequest<BannerDTOUpdateRequest> request = new()
            {
                URL = "/api/Banner/DeleteBanner",
                Body= bannerDTOUpdateRequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<BannerDTOUpdateRequest>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["DeleteBannerError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","Banner");
            }
            else
            {
                ViewData["DeleteBannerSuccess"] = "Başarılı !";
                return RedirectToAction("Index","Banner");
            }
        }
    }
}
