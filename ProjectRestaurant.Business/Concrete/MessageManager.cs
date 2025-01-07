using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.MessageDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        public Task<ApiResponse<MessageDTOResponse>> AddAsync(MessageDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<MessageDTOResponse>>> GetAllAsync(MessageDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<MessageDTOResponse>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateAsync(MessageDTORequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
