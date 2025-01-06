using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.BannerDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class BannerManager:IBannerService
    {
        private readonly Lazy<IUnitOfWork> _uow;
        private readonly IMapper _mapper;

        public BannerManager(Lazy<IUnitOfWork> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<BannerDTOResponse> AddAsync(BannerDTORequest entity)
        {
            Banner Banner = _mapper.Map<Banner>(entity);
            await _uow.Value.BannerRepository.AddAsync(Banner);
            await _uow.Value.SaveChangeAsync();

            BannerDTOResponse BannerDTOResponse = _mapper.Map<BannerDTOResponse>(Banner);
            return BannerDTOResponse;
        }

        public async Task DeleteAsync(BannerDTORequest entity)
        {
            Banner Banner = _mapper.Map<Banner>(entity);
            await _uow.Value.BannerRepository.RemoveAsync(Banner);
            await _uow.Value.SaveChangeAsync();
        }

        public async Task<List<BannerDTOResponse>> GetAllAsync(BannerDTORequest entity)
        {
            var Banners = await _uow.Value.BannerRepository.GetAllAsync(x => true);
            List<BannerDTOResponse> BannerDTOResponses = new();
            foreach (var Banner in Banners)
            {
                BannerDTOResponses.Add(_mapper.Map<BannerDTOResponse>(Banner));
            }
            return BannerDTOResponses;
        }

        public async Task<BannerDTOResponse> GetAsync(BannerDTORequest entity)
        {
            var Banner = await _uow.Value.BannerRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            var BannerResponse = _mapper.Map<BannerDTOResponse>(Banner);
            return BannerResponse;
        }

        public async Task UpdateAsync(BannerDTORequest entity)
        {
            var Banner = await _uow.Value.BannerRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            Banner = _mapper.Map(entity, Banner);
            await _uow.Value.BannerRepository.UpdateAsync(Banner);
            await _uow.Value.SaveChangeAsync();
        }
    }
}
