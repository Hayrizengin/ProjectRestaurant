using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.FoodDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Response;
using ProjectRestaurant.Tools.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class FoodManager : IFoodService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenericValidator _validator;
        public FoodManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ApiResponse<FoodDTOResponse>> AddAsync(FoodDTORequest entity)
        {
            //_validator.ValidateAsync(entity,typeof(FoodDTOAddValidator));
            var food = _mapper.Map<Food>(entity);

            await _uow.FoodRepository.AddAsync(food);
            await _uow.SaveChangeAsync();

            var foodResponse = _mapper.Map<FoodDTOResponse>(food);
            return ApiResponse<FoodDTOResponse>.SuccessResult(foodResponse);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(FoodDTOUpdateRequest foodDTOUpdateRequest)
        {
            var food = await _uow.FoodRepository.GetAsync(x=>x.Id == foodDTOUpdateRequest.Id && x.IsActive == true && x.IsDeleted == false,"FoodCategory");

            if (food is null)
            {
                var error = new ErrorResult(new List<string> { $"{foodDTOUpdateRequest.Id}'sine sahip ürün bulunamadı." });
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            food.IsActive = false;
            food.IsDeleted = true;

            _uow.FoodRepository.Update(food);
            await _uow.SaveChangeAsync();

            var foodResponse = _mapper.Map<FoodDTOResponse>(food);
            return ApiResponse<bool>.SuccessResult(true);
        }

        public async Task<ApiResponse<IEnumerable<FoodDTOResponse>>> GetAllAsync(FoodDTORequest? entity)
        {
            var foods = await _uow.FoodRepository.GetAllAsync(x=>x.IsActive == true && x.IsDeleted == false , "FoodCategory");

            if (!foods.Any())
            {
                var error = new ErrorResult(new List<string> { "Veri bulunamadı." });
                return ApiResponse<IEnumerable<FoodDTOResponse>>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var foodResponses = _mapper.Map<IEnumerable<FoodDTOResponse>>(foods);
            return ApiResponse<IEnumerable<FoodDTOResponse>>.SuccessResult(foodResponses);
        }

        public async Task<ApiResponse<FoodDTOResponse>> GetAsync(int id)
        {
            var food = await _uow.FoodRepository.GetAsync(x=>x.Id == id && x.IsActive == true && x.IsDeleted == false,"FoodCategory");

            if (food is null)
            {
                var error = new ErrorResult(new List<string> { $"{id}'sine sahip bir yemek bulunamadı." });
                return ApiResponse<FoodDTOResponse>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var foodResponse = _mapper.Map<FoodDTOResponse>(food);
            return ApiResponse<FoodDTOResponse>.SuccessResult(foodResponse);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(FoodDTOUpdateRequest entity)
        {
            var food = await _uow.FoodRepository.GetAsync(x=>x.Id == entity.Id && x.IsActive == true && x.IsDeleted == false,"FoodCategory");

            if (entity.ImageUrl is null && food.ImageUrl is not null)
                entity.ImageUrl = food.ImageUrl;

            if (food is null)
            {
                var error = new ErrorResult(new List<string> { $"{entity.Name} isimli yemek bulunamadı." });
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }
            entity.Id = food.Id;
            entity.Guid = food.Guid;
            _mapper.Map(entity,food);

            _uow.FoodRepository.Update(food);
            await _uow.SaveChangeAsync();

            var foodResponse = _mapper.Map<FoodDTOResponse>(food);
            return ApiResponse<bool>.SuccessResult(true);
        }
    }
}
