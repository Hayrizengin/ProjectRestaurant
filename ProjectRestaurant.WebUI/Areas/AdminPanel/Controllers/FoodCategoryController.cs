using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Entity.DTO.FoodCategoryDTO;
using ProjectRestaurant.WebUI.Helper.APIHelper;
using ProjectRestaurant.WebUI.Helper.SessionHelper;
using ProjectRestaurant.WebUI.Model.DTO.FoodCategory;
using System.Net;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class FoodCategoryController : Controller
    {
        private readonly IApiService _apiService;

        public FoodCategoryController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpPost("/FoodCategory/AddFoodCategory")]
        public async Task<IActionResult> AddFoodCategory(FoodCategoryDTORequest foodCategoryDTO)
        {
            ApiRequest<FoodCategoryDTORequest> request = new()
            {
                URL = "/api/FoodCategory/AddFoodCategory",
                Body = foodCategoryDTO,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestAsync<FoodCategoryDTORequest, FoodCategoryDTOResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["AddFoodCategoryError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","Food");
            }
            else
            {
                ViewData["AddFoodCategorySuccess"] = response.Message;
                return RedirectToAction("Index", "Food");
            }
        }

        [HttpPost("/FoodCategory/UpdateFoodCategory")]
        public async Task<IActionResult> UpdateFoodCategory(FoodCategoryDTOUpdateRequest foodCategoryDTOUpdateRequest)
        {
            ApiRequest<FoodCategoryDTOUpdateRequest> request = new()
            {
                URL = "/api/FoodCategory/UpdateFoodCategory",
                Body = foodCategoryDTOUpdateRequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<FoodCategoryDTOUpdateRequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["UpdateFoodCategoryError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","Food");
            }
            else
            {
                ViewData["UpdateFoodCategorySuccess"] = response.Message;
                return RedirectToAction("Index","Food");
            }
        }

        [HttpPost("/FoodCategory/DeleteFoodCategory")]
        public async Task<IActionResult> DeleteFoodCategory(FoodCategoryDTOUpdateRequest foodCategoryDTOUpdateRequest)
        {
            ApiRequest<FoodCategoryDTOUpdateRequest> request = new()
            {
                URL = "/api/FoodCategory/DeleteFoodCategory",
                Body = foodCategoryDTOUpdateRequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<FoodCategoryDTOUpdateRequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["DeleteFoodCategoryError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","Food");
            }
            else
            {
                ViewData["DeleteFoodCategorySuccess"] = response.Message;
                return RedirectToAction("Index","Food");
            }
        }
    }
}
