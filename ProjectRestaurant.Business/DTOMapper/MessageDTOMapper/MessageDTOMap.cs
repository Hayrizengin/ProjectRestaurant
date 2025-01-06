using AutoMapper;
using ProjectRestaurant.Entity.DTO.MessageDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.DTOMapper.MessageDTOMapper
{
    public class MessageDTOMap:Profile
    {
        public MessageDTOMap()
        {
            //request
            CreateMap<MessageDTORequest, Message>();
            CreateMap<Message, MessageDTORequest>();

            //response
            CreateMap<MessageDTOResponse, Message>();
            CreateMap<Message, MessageDTOResponse>();

            //etc
        }
    }
}
