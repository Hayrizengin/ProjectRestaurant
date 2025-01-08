using AutoMapper;
using ProjectRestaurant.Entity.DTO.SpecialRecipeDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.DTOMapper.SpecialRecipeDTOMapper
{
    public class SpecialRecipeDTOMap:Profile
    {
        public SpecialRecipeDTOMap()
        {
            //request
            CreateMap<SpecialRecipeDTORequest, SpecialRecipe>();
            CreateMap<SpecialRecipe, SpecialRecipeDTORequest>();

            //response
            CreateMap<SpecialRecipeDTOResponse, SpecialRecipe>();
            CreateMap<SpecialRecipe,SpecialRecipeDTOResponse>();

            //addRequest
            CreateMap<SpecialRecipeDTOAddRequest, SpecialRecipe>();
            CreateMap<SpecialRecipe, SpecialRecipeDTOAddRequest>();

            //etc
        }
    }
}
