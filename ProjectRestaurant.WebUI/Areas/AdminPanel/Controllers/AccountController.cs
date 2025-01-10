using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Entity.DTO.LoginDTO;
using ProjectRestaurant.WebUI.Helper.APIHelper;
using ProjectRestaurant.WebUI.Helper.SessionHelper;
using System.Net;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AccountController : Controller
    {
        private readonly IApiService _apiService;

        public AccountController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("/Admin/Login")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost("/Account/AdminLogin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogin(LoginDTORequest loginDTORequest)
        {
            ApiRequest<LoginDTORequest> request = new()
            {
                URL = "api/User/Login",
                Method = HttpMethod.Post,
                Body = loginDTORequest
            };

            var response = await _apiService.SendRequestAsync<LoginDTORequest,LoginDTOResponse>(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewData["LoginError"] = "Kullanıcı Adı Veya Şifre Yanlış";
                return View("LoginPage");
            }
            else
            {
                SessionManager.loginDTOResponse = response.Data;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost("/Admin/Logout")]
        public IActionResult Logout()
        {
            SessionManager.loginDTOResponse = null;
            return RedirectToAction("LoginPage", "Account");
        }
    }
}
