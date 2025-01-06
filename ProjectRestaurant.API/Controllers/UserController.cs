using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurant.Business.Abstract;
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

        [HttpGet("/GetAll")]
        public async Task<IActionResult> GetAllUsers(UserDTORequest userDTORequest)
        {
            var users = await _userService.GetAllAsync(userDTORequest);
            return Ok(ApiResponse<List<UserDTOResponse>>.SuccessResult(users));
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserDTORequest userDTORequest)
        {
            var user = await _userService.AddAsync(userDTORequest);
            return Ok(ApiResponse<UserDTOResponse>.SuccessResult(user));
        }
    }
}
