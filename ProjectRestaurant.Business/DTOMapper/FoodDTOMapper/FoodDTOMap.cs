using AutoMapper;
using ProjectRestaurant.Entity.DTO.FoodDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.DTOMapper.FoodDTOMapper
{
    public class FoodDTOMap:Profile
    {
        public FoodDTOMap()
        {
            //request
            CreateMap<FoodDTORequest, Food>();
            CreateMap<Food, FoodDTORequest>();

            //response
            CreateMap<Food, FoodDTOResponse>()
            .ForMember(dest => dest.FoodCategoryName, opt =>
            {
                opt.MapFrom(src => src.FoodCategory.Name);
            }).ReverseMap();

            //addRequest
            CreateMap<FoodDTOAddRequest, Food>();
            CreateMap<Food, FoodDTOAddRequest>();

            //etc
        }
    }
}
