using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.AboutDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class AboutManager : IGenericService<AboutDTORequest, AboutDTOResponse>
    {
        private readonly IUnitOfWork _uow;

        public AboutManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<AboutDTOResponse> AddAsync(AboutDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AboutDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<AboutDTOResponse>> GetAllAsync(AboutDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<AboutDTOResponse> GetAsync(AboutDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AboutDTORequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
