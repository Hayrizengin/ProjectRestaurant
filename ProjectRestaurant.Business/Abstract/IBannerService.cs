using ProjectRestaurant.Entity.DTO.BannerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface IBannerService:IGenericService<BannerDTORequest, BannerDTOResponse,BannerDTOAddRequest>
    {
    }
}
