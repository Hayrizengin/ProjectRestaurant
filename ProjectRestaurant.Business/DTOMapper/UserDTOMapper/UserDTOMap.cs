using AutoMapper;
using ProjectRestaurant.Entity.DTO.UserDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.DTOMapper.UserDTOMapper
{
    public class UserDTOMap:Profile
    {
        public UserDTOMap()
        {
            //request
            CreateMap<UserDTORequest, User>();
            CreateMap<User, UserDTORequest>();

            //response
            CreateMap<UserDTOResponse, User>();
            CreateMap<User, UserDTOResponse>();

            //addRequest
            CreateMap<UserDTOAddRequest, User>();
            CreateMap<User,UserDTOAddRequest>();

            //etc
        }
    }
}
