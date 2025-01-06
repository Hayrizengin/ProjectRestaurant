using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.AboutDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly Lazy<IUnitOfWork> _uow;
        private readonly IMapper _mapper;

        public AboutManager(Lazy<IUnitOfWork> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<AboutDTOResponse> AddAsync(AboutDTORequest entity)
        {
            About about = _mapper.Map<About>(entity);
            await _uow.Value.AboutRepository.AddAsync(about);
            await _uow.Value.SaveChangeAsync();

            AboutDTOResponse aboutDTOResponse = _mapper.Map<AboutDTOResponse>(about);
            return aboutDTOResponse;
        }

        public async Task DeleteAsync(AboutDTORequest entity)
        {
            About about = _mapper.Map<About>(entity);
            await _uow.Value.AboutRepository.RemoveAsync(about);
            await _uow.Value.SaveChangeAsync();
        }

        public async Task<List<AboutDTOResponse>> GetAllAsync(AboutDTORequest entity)
        {
            var abouts = await _uow.Value.AboutRepository.GetAllAsync(x=>true);
            List<AboutDTOResponse> aboutDTOResponses = new();
            foreach (var about in abouts)
            {
                aboutDTOResponses.Add(_mapper.Map<AboutDTOResponse>(about));
            }
            return aboutDTOResponses;
        }

        public async Task<AboutDTOResponse> GetAsync(AboutDTORequest entity)
        {
            var about = await _uow.Value.AboutRepository.GetAsync(x=>x.Id == entity.Id || x.Guid == entity.Guid);
            var aboutResponse = _mapper.Map<AboutDTOResponse>(about);
            return aboutResponse;
        }

        public async Task UpdateAsync(AboutDTORequest entity)
        {
            var about = await _uow.Value.AboutRepository.GetAsync(x=>x.Id == entity.Id || x.Guid == entity.Guid);
            about = _mapper.Map(entity,about);
            await _uow.Value.AboutRepository.UpdateAsync(about);
            await _uow.Value.SaveChangeAsync();
        }
    }
}
