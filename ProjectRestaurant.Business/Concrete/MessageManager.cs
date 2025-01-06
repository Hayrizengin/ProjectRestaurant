using AutoMapper;
using ProjectRestaurant.Business.Abstract;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.DTO.MessageDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Concrete
{
    public class MessageManager:IMessageService
    {
        private readonly Lazy<IUnitOfWork> _uow;
        private readonly IMapper _mapper;

        public MessageManager(Lazy<IUnitOfWork> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<MessageDTOResponse> AddAsync(MessageDTORequest entity)
        {
            Message Message = _mapper.Map<Message>(entity);
            await _uow.Value.MessageRepository.AddAsync(Message);
            await _uow.Value.SaveChangeAsync();

            MessageDTOResponse MessageDTOResponse = _mapper.Map<MessageDTOResponse>(Message);
            return MessageDTOResponse;
        }

        public async Task DeleteAsync(MessageDTORequest entity)
        {
            Message Message = _mapper.Map<Message>(entity);
            await _uow.Value.MessageRepository.RemoveAsync(Message);
            await _uow.Value.SaveChangeAsync();
        }

        public async Task<List<MessageDTOResponse>> GetAllAsync(MessageDTORequest entity)
        {
            var Messages = await _uow.Value.MessageRepository.GetAllAsync(x => true);
            List<MessageDTOResponse> MessageDTOResponses = new();
            foreach (var Message in Messages)
            {
                MessageDTOResponses.Add(_mapper.Map<MessageDTOResponse>(Message));
            }
            return MessageDTOResponses;
        }

        public async Task<MessageDTOResponse> GetAsync(MessageDTORequest entity)
        {
            var Message = await _uow.Value.MessageRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            var MessageResponse = _mapper.Map<MessageDTOResponse>(Message);
            return MessageResponse;
        }

        public async Task UpdateAsync(MessageDTORequest entity)
        {
            var Message = await _uow.Value.MessageRepository.GetAsync(x => x.Id == entity.Id || x.Guid == entity.Guid);
            Message = _mapper.Map(entity, Message);
            await _uow.Value.MessageRepository.UpdateAsync(Message);
            await _uow.Value.SaveChangeAsync();
        }
    }
}
