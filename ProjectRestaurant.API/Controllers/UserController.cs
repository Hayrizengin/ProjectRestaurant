using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.LoginDTO;
using ProjectRestaurant.Entity.DTO.UserDTO;
using ProjectRestaurant.Tools.Response;
using System.Net;

namespace ProjectRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserDTORequest userDTOAddRequest)
        {
            var result = await _userService.AddAsync(userDTOAddRequest);
            return Ok(result);
        }

        [HttpPost("GetUsers")]
        [ProducesResponseType(typeof(List<UserDTOResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers(UserDTORequest userDTOAddRequest)
        {
            var result = await _userService.GetAllAsync(userDTOAddRequest);
            return Ok(result);
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTOUpdateRequest userDTORequest)
        {
            var result = await _userService.UpdateAsync(userDTORequest);
            return Ok(result);
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(UserDTOUpdateRequest userDTOUpdateRequest)
        {
            var result = await _userService.DeleteAsync(userDTOUpdateRequest);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTORequest loginDTORequest)
        {
            var result = await _userService.LoginAsync(loginDTORequest);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

    }
}
