using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.ContactDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class ContactManager:IContactService
    {
        private readonly Lazy<IUnitOfWork> _uow;
        private readonly IMapper _mapper;

        public ContactManager(Lazy<IUnitOfWork> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ContactDTOResponse> AddAsync(ContactDTORequest entity)
        {
            Contact Contact = _mapper.Map<Contact>(entity);
            await _uow.Value.ContactRepository.AddAsync(Contact);
            await _uow.Value.SaveChangeAsync();

            ContactDTOResponse ContactDTOResponse = _mapper.Map<ContactDTOResponse>(Contact);
            return ContactDTOResponse;
        }

        public async Task DeleteAsync(ContactDTORequest entity)
        {
            Contact Contact = _mapper.Map<Contact>(entity);
            await _uow.Value.ContactRepository.RemoveAsync(Contact);
            await _uow.Value.SaveChangeAsync();
        }

        public async Task<List<ContactDTOResponse>> GetAllAsync(ContactDTORequest entity)
        {
            var Contacts = await _uow.Value.ContactRepository.GetAllAsync(x => true);
            List<ContactDTOResponse> ContactDTOResponses = new();
            foreach (var Contact in Contacts)
            {
                ContactDTOResponses.Add(_mapper.Map<ContactDTOResponse>(Contact));
            }
            return ContactDTOResponses;
        }

        public async Task<ContactDTOResponse> GetAsync(ContactDTORequest entity)
        {
            var Contact = await _uow.Value.ContactRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            var ContactResponse = _mapper.Map<ContactDTOResponse>(Contact);
            return ContactResponse;
        }

        public async Task UpdateAsync(ContactDTORequest entity)
        {
            var Contact = await _uow.Value.ContactRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            Contact = _mapper.Map(entity, Contact);
            await _uow.Value.ContactRepository.UpdateAsync(Contact);
            await _uow.Value.SaveChangeAsync();
        }
    }
}
