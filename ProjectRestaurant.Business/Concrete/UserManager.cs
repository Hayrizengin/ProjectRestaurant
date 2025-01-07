using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.Business.Validator.LoginValidation;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.LoginDTO;
using ProjectRestaurant.Entity.DTO.UserDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Exceptions;
using ProjectRestaurant.Tools.Response;
using ProjectRestaurant.Tools.Security;
using ProjectRestaurant.Tools.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class UserManager : IUserService
    {
        public Task<ApiResponse<UserDTOResponse>> AddAsync(UserDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<UserDTOResponse>>> GetAllAsync(UserDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserDTOResponse>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserDTOResponse>> GetUserByEMailAsync(string eMailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<LoginDTOResponse>> LoginAsync(LoginDTORequest loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateAsync(UserDTORequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
