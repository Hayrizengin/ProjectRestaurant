using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Entity.DTO.LoginDTO;
using ProjectRestaurant.Entity.DTO.UserDTO;
using ProjectRestaurant.Tools.Response;

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

        [HttpPost("/AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserDTOAddRequest userDTOAddRequest)
        {
            var result = await _userService.AddAsync(userDTOAddRequest);
            return Ok(result);
        }

        [HttpPost("/Users")]
        [ProducesResponseType(typeof(List<UserDTOResponse>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers(UserDTOAddRequest userDTOAddRequest)
        {
            var result = await _userService.GetAllAsync(userDTOAddRequest);
            return Ok(result);
        }

        [HttpGet("/User/{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var result = await _userService.GetAsync(userId);
            return Ok(result);
        }

        [HttpPut("/UpdateUser/{idOrGuid}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTORequest userDTORequest)
        {
            var result = await _userService.UpdateAsync(userDTORequest);
            return Ok(result);
        }

        [HttpDelete("/DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteAsync(userId);
            return Ok(result);
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginDTORequest loginDTORequest)
        {
            var result = await _userService.LoginAsync(loginDTORequest);
            return Ok(result);
        }

    }
}
