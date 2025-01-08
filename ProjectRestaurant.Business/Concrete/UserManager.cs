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
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenericValidator _validator;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public UserManager(IGenericValidator validator, IMapper mapper, IUnitOfWork uow, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _validator = validator;
            _mapper = mapper;
            _uow = uow;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse<UserDTOResponse>> AddAsync(UserDTOAddRequest entity)
        {
            await _validator.ValidateAsync(entity,typeof(UserRegisterValidator));
            // Kullanıcı şifresini hashle
            var hashedPassword = _passwordHasher.HashPassword(entity.Password);
            var user = _mapper.Map<User>(entity);
            user.Password = hashedPassword;

            await _uow.UserRepository.AddAsync(user);
            await _uow.SaveChangeAsync();

            var userResponse = _mapper.Map<UserDTOResponse>(user);
            return ApiResponse<UserDTOResponse>.SuccessResult(userResponse);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var user = await _uow.UserRepository.GetAsync(x=>x.Id == id);

            if (user == null)
            {
                var error = new ErrorResult(new List<string>
                {
                    "Silinecek kullanıcı bulunamadı."
                });
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            user.IsActive = false;
            user.IsDeleted = true;
            _uow.UserRepository.Update(user);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);
        }

        public async Task<ApiResponse<IEnumerable<UserDTOResponse>>> GetAllAsync(UserDTOAddRequest? entity)
        {
            var users = await _uow.UserRepository.GetAllAsync();

            if (!users.Any())
            {
                var error = new ErrorResult(new List<string> {"Kullanıcı kaydı bulunamadı"});
                return ApiResponse<IEnumerable<UserDTOResponse>>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var userDTOResponses = _mapper.Map<IEnumerable<UserDTOResponse>>(users);
            return ApiResponse<IEnumerable<UserDTOResponse>>.SuccessResult(userDTOResponses);
        }

        public async Task<ApiResponse<UserDTOResponse>> GetAsync(int id)
        {
            var user = await _uow.UserRepository.GetAsync(x=>x.Id == id && x.IsActive == true && x.IsDeleted == false);

            if (user is null)
            {
                var error = new ErrorResult(new List<string>
                {
                    "Kullanıcı bulunamadı."
                });
                return ApiResponse<UserDTOResponse>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var userDTOResponse = _mapper.Map<UserDTOResponse>(user);
            return ApiResponse<UserDTOResponse>.SuccessResult(userDTOResponse);

        }

        public async Task<ApiResponse<UserDTOResponse>> GetUserByEMailAsync(string eMailAddress)
        {
            var user = await _uow.UserRepository.GetAsync(x=>x.Email.ToLower() == eMailAddress.ToLower() && x.IsDeleted == false);

            if (user is null)
            {
                var error = new ErrorResult(new List<string>
                {
                    "Eşleşen e-posta bulunamadı."
                });
                return ApiResponse<UserDTOResponse>.FailureResult(error,HttpStatusCode.NotFound);
            }

            return ApiResponse<UserDTOResponse>.SuccessResult(_mapper.Map<UserDTOResponse>(user));
        }

        public async Task<ApiResponse<LoginDTOResponse>> LoginAsync(LoginDTORequest loginRequestDTO)
        {
            await _validator.ValidateAsync(loginRequestDTO,typeof(LoginValidator));

            var user = await _uow.UserRepository.GetAsync(x=>x.Email == loginRequestDTO.Email && x.IsActive==true && x.IsDeleted==false);

            if (user == null || !_passwordHasher.VerifyPassword(user.Password,loginRequestDTO.Password))
            {
                var error = new ErrorResult(new List<string>{
                    "Kullanıcı adı veya şifre yanlış."
                });
                return ApiResponse<LoginDTOResponse>.FailureResult(error,HttpStatusCode.NotFound);
            }
            else
            {
                var claims = new List<Claim>()
                {
                    new Claim("UserGuid",user.Guid.ToString()),
                    new Claim("UserEMail",user.Email)
                };
                var token = _tokenService.GenerateToken(claims);
                var loginResponseDTO = _mapper.Map<LoginDTOResponse>(user);
                loginResponseDTO.Token = token;
                return ApiResponse<LoginDTOResponse>.SuccessResult(loginResponseDTO);
            }
        }

        public async Task<ApiResponse<bool>> UpdateAsync(UserDTORequest entity)
        {
            await _validator.ValidateAsync(entity,typeof(UserUpdateValidator));

            var user = await _uow.UserRepository.GetAsync(x=>x.Id == entity.Id || x.Guid == entity.Guid);

            if (user is null)
            {
                var error = new ErrorResult(new List<string>
                {
                    "Güncellenecek kullanıcı bulunamadı."
                });
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            _mapper.Map(entity,user);

            _uow.UserRepository.Update(user);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);

        }
    }
}
