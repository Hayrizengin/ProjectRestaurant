using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.MessageDTO;
using ProjectRestaurant.Entity.DTO.MessageDTO;
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
    public class MessageManager : IMessageService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenericValidator _validator;

        public MessageManager(IGenericValidator validator, IMapper mapper, IUnitOfWork uow)
        {
            _validator = validator;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ApiResponse<MessageDTOResponse>> AddAsync(MessageDTORequest entity)
        {
            //await _validator.ValidateAsync(entity,typeof(MessageValidator));

            var message = _mapper.Map<Message>(entity);

            await _uow.MessageRepository.AddAsync(message);
            await _uow.SaveChangeAsync();

            var messageResponse = _mapper.Map<MessageDTOResponse>(message);
            return ApiResponse<MessageDTOResponse>.SuccessResult(messageResponse);
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var message = await _uow.MessageRepository.GetAsync(x => x.Id == id);

            if (message is null)
            {
                var error = new ErrorResult(new List<string>
                {
                    $"{id}'li veri bulunamadı."
                });
                return ApiResponse<bool>.FailureResult(error, HttpStatusCode.NotFound);
            }

            message.IsActive = false;
            message.IsDeleted = true;
            _uow.MessageRepository.Update(message);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);
        }

        public async Task<ApiResponse<IEnumerable<MessageDTOResponse>>> GetAllAsync(MessageDTORequest? entity)
        {
            var messages = await _uow.MessageRepository.GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);

            if (!messages.Any())
            {
                var error = new ErrorResult(new List<string>
                {
                    "Veri bulunamadı."
                });
                return ApiResponse<IEnumerable<MessageDTOResponse>>.FailureResult(error, HttpStatusCode.NotFound);
            }

            var messageDTOResponses = _mapper.Map<IEnumerable<MessageDTOResponse>>(messages);
            return ApiResponse<IEnumerable<MessageDTOResponse>>.SuccessResult(messageDTOResponses);
        }

        public async Task<ApiResponse<MessageDTOResponse>> GetAsync(int id)
        {
            var message = await _uow.MessageRepository.GetAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);

            if (message is null)
            {
                var error = new ErrorResult(new List<string> { $"{id}'sine sahip veri bulunamadı" });
                return ApiResponse<MessageDTOResponse>.FailureResult(error, HttpStatusCode.NotFound);
            }

            var messageDTOResponse = _mapper.Map<MessageDTOResponse>(message);
            return ApiResponse<MessageDTOResponse>.SuccessResult(messageDTOResponse);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(MessageDTOUpdateRequest entity)
        {
            var message = await _uow.MessageRepository.GetAsync(x => x.Id == entity.Id && x.IsActive == true && x.IsDeleted == false);

            if (message is null)
            {
                var error = new ErrorResult(new List<string> { $"{entity.Email} ile ilgili veri bulunamadı." });
                return ApiResponse<bool>.FailureResult(error, HttpStatusCode.NotFound);
            }
            entity.Id = message.Id;
            entity.Guid = message.Guid;
            _mapper.Map(entity, message);

            _uow.MessageRepository.Update(message);
            await _uow.SaveChangeAsync();

            return ApiResponse<bool>.SuccessResult(true);

        }
    }
}
