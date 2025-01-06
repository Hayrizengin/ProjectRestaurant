using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.SpecialRecipeDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class SpecialRecipeManager:ISpecialRecipeService
    {
        private readonly Lazy<IUnitOfWork> _uow;
        private readonly IMapper _mapper;

        public SpecialRecipeManager(Lazy<IUnitOfWork> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<SpecialRecipeDTOResponse> AddAsync(SpecialRecipeDTORequest entity)
        {
            SpecialRecipe SpecialRecipe = _mapper.Map<SpecialRecipe>(entity);
            await _uow.Value.SpecialRecipeRepository.AddAsync(SpecialRecipe);
            await _uow.Value.SaveChangeAsync();

            SpecialRecipeDTOResponse SpecialRecipeDTOResponse = _mapper.Map<SpecialRecipeDTOResponse>(SpecialRecipe);
            return SpecialRecipeDTOResponse;
        }

        public async Task DeleteAsync(SpecialRecipeDTORequest entity)
        {
            SpecialRecipe SpecialRecipe = _mapper.Map<SpecialRecipe>(entity);
            await _uow.Value.SpecialRecipeRepository.RemoveAsync(SpecialRecipe);
            await _uow.Value.SaveChangeAsync();
        }

        public async Task<List<SpecialRecipeDTOResponse>> GetAllAsync(SpecialRecipeDTORequest entity)
        {
            var SpecialRecipes = await _uow.Value.SpecialRecipeRepository.GetAllAsync(x => true);
            List<SpecialRecipeDTOResponse> SpecialRecipeDTOResponses = new();
            foreach (var SpecialRecipe in SpecialRecipes)
            {
                SpecialRecipeDTOResponses.Add(_mapper.Map<SpecialRecipeDTOResponse>(SpecialRecipe));
            }
            return SpecialRecipeDTOResponses;
        }

        public async Task<SpecialRecipeDTOResponse> GetAsync(SpecialRecipeDTORequest entity)
        {
            var SpecialRecipe = await _uow.Value.SpecialRecipeRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            var SpecialRecipeResponse = _mapper.Map<SpecialRecipeDTOResponse>(SpecialRecipe);
            return SpecialRecipeResponse;
        }

        public async Task UpdateAsync(SpecialRecipeDTORequest entity)
        {
            var SpecialRecipe = await _uow.Value.SpecialRecipeRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            SpecialRecipe = _mapper.Map(entity, SpecialRecipe);
            await _uow.Value.SpecialRecipeRepository.UpdateAsync(SpecialRecipe);
            await _uow.Value.SaveChangeAsync();
        }
    }
}
