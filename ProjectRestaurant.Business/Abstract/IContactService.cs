using ProjectRestaurant.Entity.DTO.ContactDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface IContactService:IGenericService<ContactDTORequest,ContactDTOResponse,ContactDTOUpdateRequest>
    {
    }
}
