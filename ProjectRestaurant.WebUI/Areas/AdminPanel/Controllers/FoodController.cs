using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Entity.DTO.FoodCategoryDTO;
using ProjectRestaurant.Entity.DTO.FoodDTO;
using ProjectRestaurant.WebUI.Areas.AdminPanel.Models;
using ProjectRestaurant.WebUI.Helper.APIHelper;
using ProjectRestaurant.WebUI.Helper.SessionHelper;
using System.Net;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class FoodController : Controller
    {
        private readonly IApiService _apiService;

        public FoodController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("/Admin/Food")]
        public async Task<IActionResult> Index()
        {
            ApiRequest<FoodDTORequest> foodRequest = new()
            {
                Body = new FoodDTORequest(),
                URL = "/api/Food/GetFoods",
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            ApiRequest<FoodCategoryDTORequest> foodCategoryRequest = new()
            {
                Body = new FoodCategoryDTORequest(),
                URL = "/api/FoodCategory/GetFoodCategories",
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var foodResponse = await _apiService.SendRequestAsync<FoodDTORequest, List<FoodDTOResponse>>(foodRequest);
            var foodCategoryResponse = await _apiService.SendRequestAsync<FoodCategoryDTORequest, List<FoodCategoryDTOResponse>>(foodCategoryRequest);

            FoodViewModel foodViewModel = new FoodViewModel()
            {
                Foods = foodResponse.Data,
                FoodCategories = foodCategoryResponse.Data
            };
            return View(foodViewModel);
        }

        [HttpPost("/Food/AddFood")]
        public async Task<IActionResult> AddFood(FoodDTORequest foodDTORequest)
        {
            ApiRequest<FoodDTORequest> request = new()
            {
                Body = foodDTORequest,
                URL = "/api/Food/AddFood",
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestAsync<FoodDTORequest,FoodDTOResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["AddFoodError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","Food");
            }
            else
            {
                ViewData["AddFoodSuccess"] = response.Message;
                return RedirectToAction("Index","Food");
            }
        }

        [HttpPost("/Food/UpdateFood")]
        public async Task<IActionResult> UpdateFood(FoodDTORequest foodDTORequest)
        {
            ApiRequest<FoodDTORequest> request = new()
            {
                Body = foodDTORequest,
                URL = "/api/Food/UpdateFood",
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<FoodDTORequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["UpdateFoodError"] = response.Error.Errors;
                return RedirectToAction("Index","Food");
            }
            else
            {
                ViewData["UpdateFoodSuccess"] = response.Message;
                return RedirectToAction("Index","Food");
            }
        }

        [HttpPost("/Food/DeleteFood")]
        public async Task<IActionResult> DeleteFood(FoodDTORequest foodDTORequest)
        {
            ApiRequest<FoodDTORequest> request = new()
            {
                Body = foodDTORequest,
                URL = "/api/Food/DeleteFood",
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<FoodDTORequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["DeleteFoodError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","Food");
            }
            else
            {
                ViewData["DeleteFoodSuccess"] = response.Message;
                return RedirectToAction("Index","Food");
            }
        }
    }
}
