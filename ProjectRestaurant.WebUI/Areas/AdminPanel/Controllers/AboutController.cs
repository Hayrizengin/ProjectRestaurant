using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Entity.DTO.AboutDTO;
using ProjectRestaurant.WebUI.Areas.AdminPanel.Models;
using ProjectRestaurant.WebUI.Helper.APIHelper;
using ProjectRestaurant.WebUI.Helper.SessionHelper;
using ProjectRestaurant.WebUI.Model.DTO.About;
using ProjectRestaurant.WebUI.Model.DTO.User;
using System.Net;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AboutController : Controller
    {
        private readonly IApiService _apiService;

        public AboutController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("/Admin/Hakkında")]
        public async Task<IActionResult> Index()
        {
            var abouts = await _apiService.SendRequestAsync<AboutDTORequest, List<AboutDTOResponse>>(new ApiRequest<AboutDTORequest>
            {
                Body = new AboutDTORequest(),
                Method = HttpMethod.Post,
                URL = "/api/About/GetAbouts",
                //Token = SessionManager.loginDTOResponse.Token
            });

            AboutViewModel aboutViewModel = new AboutViewModel()
            {
                Abouts = abouts.Data
            };
            return View(aboutViewModel);
        }

        [HttpPost("/About/AddAbout")]
        public async Task<IActionResult> AddAbout(AboutDTORequest aboutDTORequest, IFormFile ImageUrl)
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
                aboutDTORequest.ImageUrl = base64String;
            }

            ApiRequest<AboutDTORequest> request = new()
            {
                URL = "/api/About/AddAbout",
                Body = aboutDTORequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestAsync<AboutDTORequest,AboutDTOResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["AddAboutError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index", "About");
            }
            else
            {
                ViewData["AddAboutSuccess"] = "Başarılı !";
                return RedirectToAction("Index", "About");
            }
        }

        [HttpPost("/About/UpdateAbout")]
        public async Task<IActionResult> UpdateAbout(AboutDTOUpdateRequest aboutDTOUpdateRequest,IFormFile ImageUrl)
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
                aboutDTOUpdateRequest.ImageUrl = base64String;
            }

            ApiRequest<AboutDTOUpdateRequest> request = new()
            {
                URL = "/api/About/UpdateAbout",
                Body = aboutDTOUpdateRequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<AboutDTOUpdateRequest> (request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["UpdateAboutError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index", "About");
            }
            else
            {
                ViewData["UpdateAboutSuccess"] = "Başarılı !";
                return RedirectToAction("Index","About");
            }
        }

        [HttpPost("/About/DeleteAbout")]
        public async Task<IActionResult> DeleteAbout(AboutDTOUpdateRequest aboutDTOUpdateRequest)
        {
            ApiRequest<AboutDTOUpdateRequest> request = new()
            {
                URL = "/api/About/DeleteAbout",
                Body = aboutDTOUpdateRequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<AboutDTOUpdateRequest>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["DeleteAboutError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","About");
            }
            else
            {
                ViewData["DeleteAboutSuccess"] = "Başarılı !";
                return RedirectToAction("Index","About");
            }
        }
    }
}
