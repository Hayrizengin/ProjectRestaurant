using ProjectRestaurant.Entity.DTO.SocialMediaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface ISocialMediaService:IGenericService<SocialMediaDTORequest,SocialMediaDTOResponse,SocialMediaDTOUpdateRequest>
    {
    }
}
