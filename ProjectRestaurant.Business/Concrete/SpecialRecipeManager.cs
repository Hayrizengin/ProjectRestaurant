using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.SpecialRecipeDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class SpecialRecipeManager : ISpecialRecipeService
    {
        public Task<ApiResponse<SpecialRecipeDTOResponse>> AddAsync(SpecialRecipeDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<SpecialRecipeDTOResponse>>> GetAllAsync(SpecialRecipeDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<SpecialRecipeDTOResponse>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateAsync(SpecialRecipeDTORequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
