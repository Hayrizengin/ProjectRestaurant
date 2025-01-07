using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.FoodCategoryDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class FoodCategoryManager : IFoodCategoryService
    {
        public Task<ApiResponse<FoodCategoryDTOResponse>> AddAsync(FoodCategoryDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<FoodCategoryDTOResponse>>> GetAllAsync(FoodCategoryDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<FoodCategoryDTOResponse>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateAsync(FoodCategoryDTORequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
