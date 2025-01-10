using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Entity.DTO.AboutDTO;
using ProjectRestaurant.WebUI.Areas.AdminPanel.Models;
using ProjectRestaurant.WebUI.Helper.APIHelper;
using ProjectRestaurant.WebUI.Helper.SessionHelper;
using ProjectRestaurant.WebUI.Model.DTO.About;
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

        [HttpPost]
        public async Task<IActionResult> AddAbout(AboutDTORequest aboutDTORequest)
        {
            ApiRequest<AboutDTORequest> request = new()
            {
                URL = "/api/about/AddAbout",
                Body = aboutDTORequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestAsync<AboutDTORequest,AboutDTOResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["AddAboutError"] = response.Error.Errors.ToString();
                return View("Index","About");
            }
            else
            {
                ViewData["AddAboutOk"] = "Başarılı !";
                return View("Index","About");
            }
        }
    }
}
