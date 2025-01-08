using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.ContactDTO;
using ProjectRestaurant.Entity.Poco;
using ProjectRestaurant.Tools.Response;
using ProjectRestaurant.Tools.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenericValidator _validator;
        public ContactManager(IUnitOfWork uow, IMapper mapper, IGenericValidator validator)
        {
            _uow = uow;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ApiResponse<ContactDTOResponse>> AddAsync(ContactDTOAddRequest entity)
        {
            //_validator.ValidateAsync(entity,typeof(ContactAddValidator));
            var contact = _mapper.Map<Contact>(entity);

            await _uow.ContactRepository.AddAsync(contact);
            await _uow.SaveChangeAsync();
            
            var contactResponse = _mapper.Map<ContactDTOResponse>(contact);
            return ApiResponse<ContactDTOResponse>.SuccessResult(contactResponse);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var contact = await _uow.ContactRepository.GetAsync(x=>x.Id == id && x.IsActive == true && x.IsDeleted == false);

            if (contact is null)
            {
                var error = new ErrorResult(new List<string> { $"{id}'li veri bulunamadı" });
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            contact.IsActive = false;
            contact.IsDeleted = true;
            _uow.ContactRepository.Update(contact);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);
        }

        public async Task<ApiResponse<IEnumerable<ContactDTOResponse>>> GetAllAsync(ContactDTOAddRequest? entity)
        {
            var contacts = await _uow.ContactRepository.GetAllAsync(x=>x.IsActive == true && x.IsDeleted == false);

            if (!contacts.Any())
            {
                var error = new ErrorResult(new List<string> { "Veri bulunamadı." });
                return ApiResponse<IEnumerable<ContactDTOResponse>>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var contactDTOResponses = _mapper.Map<IEnumerable<ContactDTOResponse>>(contacts);
            return ApiResponse<IEnumerable<ContactDTOResponse>>.SuccessResult(contactDTOResponses);
        }

        public async Task<ApiResponse<ContactDTOResponse>> GetAsync(int id)
        {
            var contact = await _uow.ContactRepository.GetAsync(x=>x.Id == id && x.IsActive == true && x.IsDeleted == false);

            if (contact is null)
            {
                var error = new ErrorResult(new List<string> { $"{id}'sine sahip veri bulunamadı." });
                return ApiResponse<ContactDTOResponse>.FailureResult(error,HttpStatusCode.NotFound);
            }

            var contactResponse = _mapper.Map<ContactDTOResponse>(contact);
            return ApiResponse<ContactDTOResponse>.SuccessResult(contactResponse);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(ContactDTORequest entity)
        {
            var contact = await _uow.ContactRepository.GetAsync(x=>x.Id == entity.Id && x.IsActive == true && x.IsDeleted == false);

            if (contact is null)
            {
                var error = new ErrorResult(new List<string> { $"{entity.Id}'sine sahip veri bulunamadı." });
                return ApiResponse<bool>.FailureResult(error,HttpStatusCode.NotFound);
            }

            _mapper.Map(entity, contact);

            _uow.ContactRepository.Update(contact);
            await _uow.SaveChangeAsync();

            var contactResponse = _mapper.Map<ContactDTOResponse>(contact);
            return ApiResponse<bool>.SuccessResult(true);
        }
    }
}
