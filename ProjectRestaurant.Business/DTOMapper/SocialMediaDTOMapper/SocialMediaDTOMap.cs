using AutoMapper;
using ProjectRestaurant.Entity.DTO.SocialMediaDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.DTOMapper.SocialMediaDTOMapper
{
    public class SocialMediaDTOMap:Profile
    {
        public SocialMediaDTOMap()
        {
            //request
            CreateMap<SocialMediaDTORequest, SocialMedia>();
            CreateMap<SocialMedia, SocialMediaDTORequest>();

            //response
            CreateMap<SocialMediaDTOResponse, SocialMedia>();
            CreateMap<SocialMedia, SocialMediaDTOResponse>();

            //addRequest
            CreateMap<SocialMediaDTOAddRequest, SocialMedia>();
            CreateMap<SocialMedia, SocialMediaDTOAddRequest>();

            //etc
        }
    }
}
