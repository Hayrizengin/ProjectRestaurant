using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.FoodCategoryDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class FoodCategoryManager:IFoodCategoryService
    {
        private readonly Lazy<IUnitOfWork> _uow;
        private readonly IMapper _mapper;

        public FoodCategoryManager(Lazy<IUnitOfWork> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FoodCategoryDTOResponse> AddAsync(FoodCategoryDTORequest entity)
        {
            FoodCategory FoodCategory = _mapper.Map<FoodCategory>(entity);
            await _uow.Value.FoodCategoryRepository.AddAsync(FoodCategory);
            await _uow.Value.SaveChangeAsync();

            FoodCategoryDTOResponse FoodCategoryDTOResponse = _mapper.Map<FoodCategoryDTOResponse>(FoodCategory);
            return FoodCategoryDTOResponse;
        }

        public async Task DeleteAsync(FoodCategoryDTORequest entity)
        {
            FoodCategory FoodCategory = _mapper.Map<FoodCategory>(entity);
            await _uow.Value.FoodCategoryRepository.RemoveAsync(FoodCategory);
            await _uow.Value.SaveChangeAsync();
        }

        public async Task<List<FoodCategoryDTOResponse>> GetAllAsync(FoodCategoryDTORequest entity)
        {
            var FoodCategorys = await _uow.Value.FoodCategoryRepository.GetAllAsync(x => true);
            List<FoodCategoryDTOResponse> FoodCategoryDTOResponses = new();
            foreach (var FoodCategory in FoodCategorys)
            {
                FoodCategoryDTOResponses.Add(_mapper.Map<FoodCategoryDTOResponse>(FoodCategory));
            }
            return FoodCategoryDTOResponses;
        }

        public async Task<FoodCategoryDTOResponse> GetAsync(FoodCategoryDTORequest entity)
        {
            var FoodCategory = await _uow.Value.FoodCategoryRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            var FoodCategoryResponse = _mapper.Map<FoodCategoryDTOResponse>(FoodCategory);
            return FoodCategoryResponse;
        }

        public async Task UpdateAsync(FoodCategoryDTORequest entity)
        {
            var FoodCategory = await _uow.Value.FoodCategoryRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            FoodCategory = _mapper.Map(entity, FoodCategory);
            await _uow.Value.FoodCategoryRepository.UpdateAsync(FoodCategory);
            await _uow.Value.SaveChangeAsync();
        }
    }
}
