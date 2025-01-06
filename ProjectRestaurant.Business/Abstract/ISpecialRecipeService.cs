using ProjectRestaurant.Entity.DTO.SpecialRecipeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface ISpecialRecipeService:IGenericService<SpecialRecipeDTORequest, SpecialRecipeDTOResponse>
    {
    }
}
