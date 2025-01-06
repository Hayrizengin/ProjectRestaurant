using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.FoodDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class FoodManager:IFoodService
    {
        private readonly Lazy<IUnitOfWork> _uow;
        private readonly IMapper _mapper;

        public FoodManager(Lazy<IUnitOfWork> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<FoodDTOResponse> AddAsync(FoodDTORequest entity)
        {
            Food Food = _mapper.Map<Food>(entity);
            await _uow.Value.FoodRepository.AddAsync(Food);
            await _uow.Value.SaveChangeAsync();

            FoodDTOResponse FoodDTOResponse = _mapper.Map<FoodDTOResponse>(Food);
            return FoodDTOResponse;
        }

        public async Task DeleteAsync(FoodDTORequest entity)
        {
            Food Food = _mapper.Map<Food>(entity);
            await _uow.Value.FoodRepository.RemoveAsync(Food);
            await _uow.Value.SaveChangeAsync();
        }

        public async Task<List<FoodDTOResponse>> GetAllAsync(FoodDTORequest entity)
        {
            var Foods = await _uow.Value.FoodRepository.GetAllAsync(x => true);
            List<FoodDTOResponse> FoodDTOResponses = new();
            foreach (var Food in Foods)
            {
                FoodDTOResponses.Add(_mapper.Map<FoodDTOResponse>(Food));
            }
            return FoodDTOResponses;
        }

        public async Task<FoodDTOResponse> GetAsync(FoodDTORequest entity)
        {
            var Food = await _uow.Value.FoodRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            var FoodResponse = _mapper.Map<FoodDTOResponse>(Food);
            return FoodResponse;
        }

        public async Task UpdateAsync(FoodDTORequest entity)
        {
            var Food = await _uow.Value.FoodRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            Food = _mapper.Map(entity, Food);
            await _uow.Value.FoodRepository.UpdateAsync(Food);
            await _uow.Value.SaveChangeAsync();
        }
    }
}
