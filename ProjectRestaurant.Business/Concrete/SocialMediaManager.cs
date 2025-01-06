using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.SocialMediaDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class SocialMediaManager:ISocialMediaService
    {
        private readonly Lazy<IUnitOfWork> _uow;
        private readonly IMapper _mapper;

        public SocialMediaManager(Lazy<IUnitOfWork> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<SocialMediaDTOResponse> AddAsync(SocialMediaDTORequest entity)
        {
            SocialMedia SocialMedia = _mapper.Map<SocialMedia>(entity);
            await _uow.Value.SocialMediaRepository.AddAsync(SocialMedia);
            await _uow.Value.SaveChangeAsync();

            SocialMediaDTOResponse SocialMediaDTOResponse = _mapper.Map<SocialMediaDTOResponse>(SocialMedia);
            return SocialMediaDTOResponse;
        }

        public async Task DeleteAsync(SocialMediaDTORequest entity)
        {
            SocialMedia SocialMedia = _mapper.Map<SocialMedia>(entity);
            await _uow.Value.SocialMediaRepository.RemoveAsync(SocialMedia);
            await _uow.Value.SaveChangeAsync();
        }

        public async Task<List<SocialMediaDTOResponse>> GetAllAsync(SocialMediaDTORequest entity)
        {
            var SocialMedias = await _uow.Value.SocialMediaRepository.GetAllAsync(x => true);
            List<SocialMediaDTOResponse> SocialMediaDTOResponses = new();
            foreach (var SocialMedia in SocialMedias)
            {
                SocialMediaDTOResponses.Add(_mapper.Map<SocialMediaDTOResponse>(SocialMedia));
            }
            return SocialMediaDTOResponses;
        }

        public async Task<SocialMediaDTOResponse> GetAsync(SocialMediaDTORequest entity)
        {
            var SocialMedia = await _uow.Value.SocialMediaRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            var SocialMediaResponse = _mapper.Map<SocialMediaDTOResponse>(SocialMedia);
            return SocialMediaResponse;
        }

        public async Task UpdateAsync(SocialMediaDTORequest entity)
        {
            var SocialMedia = await _uow.Value.SocialMediaRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            SocialMedia = _mapper.Map(entity, SocialMedia);
            await _uow.Value.SocialMediaRepository.UpdateAsync(SocialMedia);
            await _uow.Value.SaveChangeAsync();
        }
    }
}
