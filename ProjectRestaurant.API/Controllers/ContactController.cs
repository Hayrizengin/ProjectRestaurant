using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.ContactDTO;

namespace ProjectRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContact(ContactDTORequest contactDTOAddRequest)
        {
            var result = await _contactService.AddAsync(contactDTOAddRequest);
            return Ok(result);
        }

        [HttpPost("GetContacts")]
        public async Task<IActionResult> GetContacts(ContactDTORequest contactDTOAddRequest)
        {
            var result = await _contactService.GetAllAsync(contactDTOAddRequest);
            return Ok(result);
        }

        [HttpGet("GetContact/{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var result = await _contactService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("UpdateContact")]
        public async Task<IActionResult> UpdateContact(ContactDTOUpdateRequest contactDTORequest)
        {
            var result = await _contactService.UpdateAsync(contactDTORequest);
            return Ok(result);
        }

        [HttpPost("DeleteContact")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
