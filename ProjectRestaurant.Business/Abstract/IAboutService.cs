using ProjectRestaurant.Entity.DTO.AboutDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface IAboutService:IGenericService<AboutDTORequest,AboutDTOResponse>
    {
    }
}
