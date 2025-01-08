using ProjectRestaurant.Entity.DTO.LoginDTO;
using ProjectRestaurant.Entity.DTO.UserDTO;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface IUserService:IGenericService<UserDTORequest,UserDTOResponse,UserDTOAddRequest>
    {
        Task<ApiResponse<LoginDTOResponse>> LoginAsync(LoginDTORequest loginRequestDTO);
        Task<ApiResponse<UserDTOResponse>> GetUserByEMailAsync(string eMailAddress);
    }
}
