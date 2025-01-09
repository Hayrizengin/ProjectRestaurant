using AutoMapper;
using ProjectRestaurant.Entity.DTO.ContactDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.DTOMapper.ContactDTOMapper
{
    public class ContactDTOMap:Profile
    {
        public ContactDTOMap()
        {
            //request
            CreateMap<ContactDTORequest, Contact>();
            CreateMap<Contact, ContactDTORequest>();

            //response
            CreateMap<ContactDTOResponse,Contact>();
            CreateMap<Contact, ContactDTOResponse>();

            //UpdateRequest
            CreateMap<ContactDTOUpdateRequest, Contact>();
            CreateMap<Contact, ContactDTOUpdateRequest>();

            //etc
        }
    }
}
