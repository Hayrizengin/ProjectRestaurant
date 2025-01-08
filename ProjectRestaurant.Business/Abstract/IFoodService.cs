using ProjectRestaurant.Entity.DTO.FoodDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface IFoodService:IGenericService<FoodDTORequest, FoodDTOResponse,FoodDTOAddRequest>
    {
    }
}
