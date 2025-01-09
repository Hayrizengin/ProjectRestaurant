using AutoMapper;
using ProjectRestaurant.Entity.DTO.AboutDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.DTOMapper.AboutDTOMapper
{
    public class AboutDTOMap:Profile
    {
        public AboutDTOMap()
        {
            //Request
            CreateMap<AboutDTORequest, About>();
            CreateMap<About, AboutDTORequest>();

            //Response
            CreateMap<AboutDTOResponse, About>();
            CreateMap<About,AboutDTOResponse>();

            //UpdateRequest
            CreateMap<AboutDTOUpdateRequest, About>();
            CreateMap<About, AboutDTOUpdateRequest>();

            //etc
        }
    }
}
