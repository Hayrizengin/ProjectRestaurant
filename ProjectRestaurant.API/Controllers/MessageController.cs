using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.MessageDTO;

namespace ProjectRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("AddMessage")]
        public async Task<IActionResult> AddMessage(MessageDTORequest messageDTOAddRequest)
        {
            var result = await _messageService.AddAsync(messageDTOAddRequest);
            return Ok(result);
        }

        [HttpPost("GetMessages")]
        public async Task<IActionResult> GetMessages(MessageDTORequest messageDTOAddRequest)
        {
            var result = await _messageService.GetAllAsync(messageDTOAddRequest);
            return Ok(result);
        }

        [HttpGet("GetMessage/{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var result = await _messageService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("UpdateMessage")]
        public async Task<IActionResult> UpdateMessage(MessageDTOUpdateRequest messageDTOUpdateRequest)
        {
            var result = await _messageService.UpdateAsync(messageDTOUpdateRequest);
            return Ok(result);
        }

        [HttpPost("DeleteMessage")]
        public async Task<IActionResult> DeleteMessage(MessageDTOUpdateRequest messageDTOUpdateRequest)
        {
            var result = await _messageService.DeleteAsync(messageDTOUpdateRequest);
            return Ok(result);
        }
    }
}
