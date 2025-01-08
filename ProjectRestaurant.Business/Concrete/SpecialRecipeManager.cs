using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.SpecialRecipeDTO;
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
    public class SpecialRecipeManager : ISpecialRecipeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IGenericValidator _validator;

        public SpecialRecipeManager(IGenericValidator validator, IUnitOfWork uow, IMapper mapper)
        {
            _validator = validator;
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ApiResponse<SpecialRecipeDTOResponse>> AddAsync(SpecialRecipeDTOAddRequest entity)
        {
            var specialRecipe = _mapper.Map<SpecialRecipe>(entity);

            await _uow.SpecialRecipeRepository.AddAsync(specialRecipe);
            await _uow.SaveChangeAsync();

            var specialRecipeDTOResponse = _mapper.Map<SpecialRecipeDTOResponse>(specialRecipe);
            return ApiResponse<SpecialRecipeDTOResponse>.SuccessResult(specialRecipeDTOResponse);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var specialRecipe = await _uow.SpecialRecipeRepository.GetAsync(x=>x.Id == id && x.IsActive == true && x.IsDeleted == false);

            if (specialRecipe is null)
            {
                var error = new ErrorResult(new List<string>{ $"{id}'sine sahip veri bulunamadı."});
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            specialRecipe.IsActive = false;
            specialRecipe.IsDeleted = true;

            _uow.SpecialRecipeRepository.Update(specialRecipe);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);
        }

        public async Task<ApiResponse<IEnumerable<SpecialRecipeDTOResponse>>> GetAllAsync(SpecialRecipeDTOAddRequest? entity)
        {
            var specialRecipes = await _uow.SpecialRecipeRepository.GetAllAsync(x=>x.IsActive == true && x.IsDeleted == false);

            if (!specialRecipes.Any())
            {
                var error = new ErrorResult(new List<string> { " Veri bulunamadı." });
                return ApiResponse<IEnumerable<SpecialRecipeDTOResponse>>.FailureResult(error, HttpStatusCode.NotFound);
            }

            var specialRecipeDTOResponses = _mapper.Map<IEnumerable<SpecialRecipeDTOResponse>>(specialRecipes);
            return ApiResponse<IEnumerable<SpecialRecipeDTOResponse>>.SuccessResult(specialRecipeDTOResponses);
        }

        public async Task<ApiResponse<SpecialRecipeDTOResponse>> GetAsync(int id)
        {
            var specialRecipe = await _uow.SpecialRecipeRepository.GetAsync(x=>x.Id == id && x.IsActive == true && x.IsDeleted == false);

            if (specialRecipe is null)
            {
                var error = new ErrorResult(new List<string> { $"{id}'sine sahip veri bulunamadı." });
                return ApiResponse<SpecialRecipeDTOResponse>.FailureResult(error, HttpStatusCode.NotFound);
            }

            var specialRecipeDTOResponse = _mapper.Map<SpecialRecipeDTOResponse>(specialRecipe);
            return ApiResponse<SpecialRecipeDTOResponse>.SuccessResult(specialRecipeDTOResponse);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(SpecialRecipeDTORequest entity)
        {
            var specialRecipe = await _uow.SpecialRecipeRepository.GetAsync(x => x.Id == entity.Id && x.IsActive == true && x.IsDeleted == false);

            if (specialRecipe is null)
            {
                var error = new ErrorResult(new List<string> { $"{entity.Id}'sine sahip veri bulunamadı." });
                return ApiResponse<bool>.FailureResult(error, HttpStatusCode.NotFound);
            }

            _mapper.Map(entity, specialRecipe);

            _uow.SpecialRecipeRepository.Update(specialRecipe);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);
        }
    }
}
