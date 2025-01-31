using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Entity.DTO.MessageDTO;
using ProjectRestaurant.WebUI.Areas.AdminPanel.Models;
using ProjectRestaurant.WebUI.Helper.APIHelper;
using ProjectRestaurant.WebUI.Helper.SessionHelper;
using System.Net;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MessageController : Controller
    {
        private readonly IApiService _apiService;

        public MessageController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("/Admin/Message")]
        public async Task<IActionResult> Index()
        {
            
            ApiRequest<MessageDTORequest> request = new()
            {
                Body = new MessageDTORequest(),
                URL = "/api/Message/GetMessages",
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token   
            };

            var messages = await _apiService.SendRequestAsync<MessageDTORequest,List<MessageDTOResponse>>(request);

            ApiRequest<MessageDTORequest> InActiveRequest = new()
            {
                Body = new MessageDTORequest() { IsActive = false },
                Method = HttpMethod.Post,
                URL = "/api/Message/GetMessages",
                //Token = SessionManager.loginDTOResponse.Token
            };

            var inActiveMessages = await _apiService.SendRequestAsync<MessageDTORequest, List<MessageDTOResponse>>(InActiveRequest);


            MessageViewModel messageViewModel = new MessageViewModel()
            {
                Messages = messages.Data,
                InActiveMessages = inActiveMessages.Data
            };
            return View(messageViewModel);
        }

        [HttpPost("/Admin/AddMessage")]
        public async Task<IActionResult> AddMessage(MessageDTORequest messageDTORequest)
        {
            ApiRequest<MessageDTORequest> request = new()
            {
                Body = messageDTORequest,
                Method = HttpMethod.Post,
                URL = "/api/Message/AddMessage",
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestAsync<MessageDTORequest, MessageDTOResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["AddMessageError"] = response.Error?.Errors;
                return RedirectToAction("Index","Message");
            }
            else
            {
                ViewData["AddMessageSuccess"] = response.Message;
                return RedirectToAction("Index","Message");
            }
        }

        [HttpPost("/Admin/UpdateMessage")]
        public async Task<IActionResult> UpdateMessage(MessageDTOUpdateRequest messageDTOUpdateRequest)
        {
            ApiRequest<MessageDTOUpdateRequest> request = new()
            {
                Body = messageDTOUpdateRequest,
                Method = HttpMethod.Post,
                URL = "/api/Message/UpdateMessage",
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<MessageDTOUpdateRequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["UpdateMessageError"] = response.Error.Errors;
                return RedirectToAction("Index","Message");
            }
            else
            {
                ViewData["UpdateMessageSuccess"] = response.Message;
                return RedirectToAction("Index","Message");
            }
        }

        [HttpPost("/Admin/DeleteMessage")]
        public async Task<IActionResult> DeleteMessage(MessageDTOUpdateRequest messageDTOUpdateRequest)
        {
            ApiRequest<MessageDTOUpdateRequest> request = new()
            {
                Body= messageDTOUpdateRequest,
                Method = HttpMethod.Post,
                URL = "/api/Message/DeleteMessage",
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<MessageDTOUpdateRequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["DeleteMessageError"] = response.Error.Errors;
                return RedirectToAction("Index", "Message");
            }
            else
            {
                ViewData["DeleteMessageSuccess"] = response.Message;
                return RedirectToAction("Index", "Message");
            }
        }

        [HttpPost("/Admin/ReadMessage")]
        public async Task<IActionResult> ReadMessage(MessageDTOUpdateRequest messageDTOUpdateRequest)
        {
            ApiRequest<MessageDTOUpdateRequest> request = new()
            {
                Body= messageDTOUpdateRequest,
                Method = HttpMethod.Post,
                URL = "/api/Message/ReadMessage",
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestAsync<MessageDTOUpdateRequest,MessageDTOResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["ReadMessageError"] = response.Error.Errors;
                return RedirectToAction("Index", "Message");
            }
            else
            {
                ViewData["ReadMessageSuccess"] = response.Message;
                return RedirectToAction("Index", "Message");
            }
        }
    }
}
