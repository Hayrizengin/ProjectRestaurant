using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.ContactDTO;
using ProjectRestaurant.Entity.DTO.FoodCategoryDTO;
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
    public class FoodCategoryManager : IFoodCategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenericValidator _validator;
        public FoodCategoryManager(IUnitOfWork uow, IMapper mapper, IGenericValidator validator)
        {
            _uow = uow;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ApiResponse<FoodCategoryDTOResponse>> AddAsync(FoodCategoryDTORequest entity)
        {
            //_validator.ValidateAsync(entity,(typeof FoodCategoryAddValidator));

            var foodCategory = _mapper.Map<FoodCategory>(entity);

            await _uow.FoodCategoryRepository.AddAsync(foodCategory);
            await _uow.SaveChangeAsync();

            var foodCategoryResponse = _mapper.Map<FoodCategoryDTOResponse>(foodCategory);
            return ApiResponse<FoodCategoryDTOResponse>.SuccessResult(foodCategoryResponse);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(FoodCategoryDTOUpdateRequest foodCategoryDTOUpdateRequest)
        {
            var foodCategory = await _uow.FoodCategoryRepository.GetAsync(x=>x.Id == foodCategoryDTOUpdateRequest.Id && x.IsActive == true && x.IsDeleted == false);

            if (foodCategory is null)
            {
                var error = new ErrorResult(new List<string> { $"{foodCategoryDTOUpdateRequest.Id}'sine sahip veri bulunamadı."});
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            foodCategory.IsActive = false;
            foodCategory.IsDeleted = true;

            _uow.FoodCategoryRepository.Update(foodCategory);
            await _uow.SaveChangeAsync();

            var foodCategoryResponse = _mapper.Map<FoodCategoryDTOResponse>(foodCategory);
            return ApiResponse<bool>.SuccessResult(true);
        }

        public async Task<ApiResponse<IEnumerable<FoodCategoryDTOResponse>>> GetAllAsync(FoodCategoryDTORequest? entity)
        {
            var foodCategories = await _uow.FoodCategoryRepository.GetAllAsync(x=>x.IsActive == true && x.IsDeleted == false);

            if (!foodCategories.Any())
            {
                var error = new ErrorResult(new List<string>{ "Veri bulunamadı." });
                return ApiResponse<IEnumerable<FoodCategoryDTOResponse>>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var foodCategoriesResponse = _mapper.Map<IEnumerable<FoodCategoryDTOResponse>>(foodCategories);
            return ApiResponse<IEnumerable<FoodCategoryDTOResponse>>.SuccessResult(foodCategoriesResponse);
        }

        public async Task<ApiResponse<FoodCategoryDTOResponse>> GetAsync(int id)
        {
            var foodCategory = await _uow.FoodCategoryRepository.GetAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);

            if (foodCategory is null)
            {
                var error = new ErrorResult(new List<string> { $"{id}'sine sahip ürün bulunamadı."});
                return ApiResponse<FoodCategoryDTOResponse>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var foodCategoryResponse = _mapper.Map<FoodCategoryDTOResponse>(foodCategory);
            return ApiResponse<FoodCategoryDTOResponse>.SuccessResult(foodCategoryResponse);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(FoodCategoryDTOUpdateRequest entity)
        {
            var foodCategory = await _uow.FoodCategoryRepository.GetAsync(x=>x.Id == entity.Id && x.IsActive == true && x.IsDeleted == false);

            if (foodCategory is null)
            {
                var error = new ErrorResult(new List<string> { $"{entity.Name}' isimli yemek kategorisi bulunamadı."});
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }
            entity.Id = foodCategory.Id;
            entity.Guid = foodCategory.Guid;
            _mapper.Map(entity,foodCategory);

            _uow.FoodCategoryRepository.Update(foodCategory);
            await _uow.SaveChangeAsync();

            var foodCategoryResponse = _mapper.Map<FoodCategoryDTOResponse>(foodCategory);
            return ApiResponse<bool>.SuccessResult(true);
        }
    }
}
