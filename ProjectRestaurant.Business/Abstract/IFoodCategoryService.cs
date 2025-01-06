using ProjectRestaurant.Entity.DTO.FoodCategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface IFoodCategoryService:IGenericService<FoodCategoryDTORequest,FoodCategoryDTOResponse>
    {
    }
}
