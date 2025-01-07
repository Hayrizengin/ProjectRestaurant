using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.SocialMediaDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        public Task<ApiResponse<SocialMediaDTOResponse>> AddAsync(SocialMediaDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<SocialMediaDTOResponse>>> GetAllAsync(SocialMediaDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<SocialMediaDTOResponse>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateAsync(SocialMediaDTORequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
