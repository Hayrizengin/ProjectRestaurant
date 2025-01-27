using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Entity.DTO.ContactDTO;
using ProjectRestaurant.WebUI.Areas.AdminPanel.Models;
using ProjectRestaurant.WebUI.Helper.APIHelper;
using ProjectRestaurant.WebUI.Helper.SessionHelper;
using System.Net;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ContactController : Controller
    {
        private readonly IApiService _apiService;

        public ContactController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("/Admin/Contact")]
        public async Task<IActionResult> Index()
        {
            var contacts = await _apiService.SendRequestAsync<ContactDTORequest, List<ContactDTOResponse>>(new ApiRequest<ContactDTORequest>
            {
                Body = new ContactDTORequest(),
                Method = HttpMethod.Post,
                URL = "/api/Contact/GetContacts",
                //Token = SessionManager.loginDTOResponse.Token
            });

            ContactViewModel contactViewModel = new ContactViewModel()
            {
                Contacts = contacts.Data
            };
            return View(contactViewModel);
        }

        [HttpPost("/Contact/AddContact")]
        public async Task<IActionResult> AddContact(ContactDTORequest contactDTORequest)
        {
            ApiRequest<ContactDTORequest> request = new()
            {
                URL = "/api/Contact/AddContact",
                Body = contactDTORequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestAsync<ContactDTORequest,ContactDTOResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewData["AddContactError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","Contact");
            }
            else
            {
                ViewData["AddContactSuccess"] = response.Message;
                return RedirectToAction("Index","Contact");
            }
        }

        [HttpPost("/Contact/UpdateContact")]
        public async Task<IActionResult> UpdateContact(ContactDTOUpdateRequest contactDTOUpdateRequest)
        {
            ApiRequest<ContactDTOUpdateRequest> request = new()
            {
                URL = "/api/Contact/UpdateContact",
                Body = contactDTOUpdateRequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<ContactDTOUpdateRequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["UpdateContactError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index","Contact");
            }
            else
            {
                ViewData["UpdateContactSuccess"] = response.Message;
                return RedirectToAction("Index","Contact");
            }
        }

        [HttpPost("/Contact/DeleteContact")]
        public async Task<IActionResult> DeleteContact(ContactDTOUpdateRequest contactDTOUpdateRequest)
        {
            ApiRequest<ContactDTOUpdateRequest> request = new()
            {
                URL = "/api/Contact/DeleteContact",
                Body = contactDTOUpdateRequest,
                Method = HttpMethod.Post,
                //Token = SessionManager.loginDTOResponse.Token
            };

            var response = await _apiService.SendRequestBoolAsync<ContactDTOUpdateRequest>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewData["DeleteContactError"] = response.Error.Errors.ToString();
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                ViewData["DeleteContactSuccess"] = response.Message;
                return RedirectToAction("Index","Contact");
            }
        }
    }
}
