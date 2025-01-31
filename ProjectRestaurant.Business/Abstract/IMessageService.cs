using ProjectRestaurant.Entity.DTO.MessageDTO;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface IMessageService:IGenericService<MessageDTORequest, MessageDTOResponse,MessageDTOUpdateRequest>
    {
        Task<ApiResponse<MessageDTOResponse>> ReadMessage(MessageDTOUpdateRequest messageDTOUpdateRequest);
    }
}
