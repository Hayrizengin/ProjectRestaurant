using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.BannerDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class BannerManager : IBannerService
    {
        public Task<ApiResponse<BannerDTOResponse>> AddAsync(BannerDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<BannerDTOResponse>>> GetAllAsync(BannerDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<BannerDTOResponse>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateAsync(BannerDTORequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
