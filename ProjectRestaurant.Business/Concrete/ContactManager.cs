using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.ContactDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class ContactManager : IContactService
    {
        public Task<ApiResponse<ContactDTOResponse>> AddAsync(ContactDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IEnumerable<ContactDTOResponse>>> GetAllAsync(ContactDTORequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<ContactDTOResponse>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> UpdateAsync(ContactDTORequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
