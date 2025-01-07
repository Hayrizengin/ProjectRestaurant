using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.FoodDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class FoodManager : IFoodService
    {
        public Task<ApiResponse<FoodDTOResponse>> AddAsync(FoodDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<FoodDTOResponse>>> GetAllAsync(FoodDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<FoodDTOResponse>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateAsync(FoodDTORequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
