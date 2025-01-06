using AutoMapper;
using ProjectRestaurant.Entity.DTO.BannerDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.DTOMapper.BannerDTOMapper
{
    public class BannerDTOMap:Profile
    {
        public BannerDTOMap()
        {
            //request
            CreateMap<BannerDTORequest, Banner>();
            CreateMap<Banner, BannerDTORequest>();

            //response
            CreateMap<BannerDTOResponse, Banner>();
            CreateMap<Banner, BannerDTOResponse>();

            //etc
        }
    }
}
