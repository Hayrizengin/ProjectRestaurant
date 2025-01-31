using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Entity.DTO.SocialMediaDTO;
using ProjectRestaurant.WebUI.Helper.APIHelper;
using ProjectRestaurant.WebUI.Helper.SessionHelper;
using System.Net;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SocialMediaController : Controller
    {
        private readonly IApiService _apiService;

        public SocialMediaController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpPost("/Admin/SocialMedia")]
        public async Task<IActionResult> Index()
        {
            ApiRequest<SocialMediaDTORequest> request = new()
            {
                Body = new SocialMediaDTORequest(),
                URL = "/api/SocialMedia/GetSocialMedias",
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var socialMedias = await _apiService.SendRequestAsync<SocialMediaDTORequest, List<SocialMediaDTOResponse>>(request);

            return View(socialMedias.Data);
        }

        [HttpPost("/Admin/AddSocialMedia")]
        public async Task<IActionResult> AddSocialMedia(SocialMediaDTORequest socialMediaDTORequest)
        {
            ApiRequest<SocialMediaDTORequest> request = new()
            {
                Body = socialMediaDTORequest,
                URL = "/api/SocialMedia/AddSocialMedia",
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestAsync<SocialMediaDTORequest,SocialMediaDTOResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["AddSocialMediaError"] = response.Error?.Errors;
                return RedirectToAction("Index","SocialMedia");
            }
            else
            {
                ViewData["AddSocialMediaSuccess"] = response.Message;
                return RedirectToAction("Index", "SocialMedia");
            }
        }

        [HttpPost("/Admin/UpdateSocialMedia")]
        public async Task<IActionResult> UpdateSocialMedia(SocialMediaDTOUpdateRequest socialMediaDTOUpdateRequest)
        {
            ApiRequest<SocialMediaDTOUpdateRequest> request = new()
            {
                Body = socialMediaDTOUpdateRequest,
                URL = "/api/SocialMedia/UpdateSocialMedia",
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse?.Token
            };

            var response = await _apiService.SendRequestBoolAsync<SocialMediaDTOUpdateRequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["UpdateSocialMediaError"] = response.Error?.Errors;
                return RedirectToAction("Index", "SocialMedia");
            }
            else
            {
                ViewData["UpdateSocialMediaSuccess"] = response.Message;
                return RedirectToAction("Index", "SocialMedia");
            }
        }

        [HttpPost("/Admin/DeleteSocialMedia")]
        public async Task<IActionResult> DeleteSocialMedia(SocialMediaDTOUpdateRequest socialMediaDTOUpdateRequest)
        {
            ApiRequest<SocialMediaDTOUpdateRequest> request = new()
            {
                Body= socialMediaDTOUpdateRequest,
                URL = "/api/SocialMedia/DeleteSocialMedia",
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse?.Token
            };

            var response = await _apiService.SendRequestBoolAsync<SocialMediaDTOUpdateRequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["DeleteSocialMediaError"] = response.Error?.Errors;
                return RedirectToAction("Index", "SocialMedia");
            }
            else
            {
                ViewData["DeleteSocialMediaSuccess"] = response.Message;
                return RedirectToAction("Index", "SocialMedia");
            }
        }
    }
}
