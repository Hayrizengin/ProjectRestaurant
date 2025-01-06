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
    public class UserManager:IUserService
    {
        private readonly Lazy<IUnitOfWork> _uow;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IGenericValidator _validator;
        private readonly IPasswordHasher _passwordHasher;

        public UserManager(Lazy<IUnitOfWork> uow, IMapper mapper, ITokenService tokenService, IGenericValidator validator, IPasswordHasher passwordHasher)
        {
            _uow = uow;
            _mapper = mapper;
            _tokenService = tokenService;
            _validator = validator;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDTOResponse> AddAsync(UserDTORequest entity)
        {
            await _validator.ValidateAsync(entity,typeof(UserRegisterValidator));
            var hashedPassword = _passwordHasher.HashPassword(entity.Password);
            User User = _mapper.Map<User>(entity);
            User.Password = hashedPassword;
            await _uow.Value.UserRepository.AddAsync(User);
            await _uow.Value.SaveChangeAsync();

            UserDTOResponse UserDTOResponse = _mapper.Map<UserDTOResponse>(User);
            return UserDTOResponse;
        }

        public async Task DeleteAsync(UserDTORequest entity)
        {
            var user = await _uow.Value.UserRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            user.IsDeleted = true;
            user.IsActive = false;

            await _uow.Value.UserRepository.UpdateAsync(user);
            await _uow.Value.SaveChangeAsync();
        }

        public async Task<List<UserDTOResponse>> GetAllAsync(UserDTORequest entity)
        {
            var Users = await _uow.Value.UserRepository.GetAllAsync(x => true);
            List<UserDTOResponse> UserDTOResponses = new();
            foreach (var User in Users)
            {
                UserDTOResponses.Add(_mapper.Map<UserDTOResponse>(User));
            }
            return UserDTOResponses;
        }

        public async Task<UserDTOResponse> GetAsync(UserDTORequest entity)
        {
            var User = await _uow.Value.UserRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            var UserResponse = _mapper.Map<UserDTOResponse>(User);
            return UserResponse;
        }
        public async Task UpdateAsync(UserDTORequest entity)
        {
            await _validator.ValidateAsync(entity, typeof(UserUpdateValidator));

            var User = await _uow.Value.UserRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            User = _mapper.Map(entity, User);
            await _uow.Value.UserRepository.UpdateAsync(User);
            await _uow.Value.SaveChangeAsync();
        }

        public async Task<ApiResponse<UserDTOResponse>> GetUserByEMailAsync(string eMailAddress)
        {
            var user = await _uow.Value.UserRepository.GetAsync(q => q.Email.ToLower() == eMailAddress.ToLower());

            if (user == null)
            {
                var error = new ErrorResult(new List<string>() { "Kullanıcı Bulunamadı" });
                return ApiResponse<UserDTOResponse>.FailureResult(error, HttpStatusCode.NotFound);
            }

            return ApiResponse<UserDTOResponse>.SuccessResult(_mapper.Map<UserDTOResponse>(user));
        }

        public async Task<ApiResponse<LoginDTOResponse>> LoginAsync(LoginDTORequest loginRequestDTO)
        {
            await _validator.ValidateAsync(loginRequestDTO, typeof(LoginValidator));
            var user = await _uow.Value.UserRepository.GetAsync(x => x.Email == loginRequestDTO.Email);

            if (user == null || !_passwordHasher.VerifyPassword(user.Password, loginRequestDTO.Password))
            {
                throw new InvalidUserCredentialsException();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim("UserGuid", user.Guid.ToString()),
                    new Claim("Email", user.Email)
                };
                var token = _tokenService.GenerateToken(claims);
                var loginResponseDTO = _mapper.Map<LoginDTOResponse>(user);
                loginResponseDTO.Token = token;
                return ApiResponse<LoginDTOResponse>.SuccessResult(loginResponseDTO);
            }
        }


    }
}
