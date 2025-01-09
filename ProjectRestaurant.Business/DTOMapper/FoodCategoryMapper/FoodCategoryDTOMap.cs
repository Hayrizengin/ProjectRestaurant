using AutoMapper;
using ProjectRestaurant.Entity.DTO.FoodCategoryDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.DTOMapper.FoodCategoryMapper
{
    public class FoodCategoryDTOMap:Profile
    {
        public FoodCategoryDTOMap()
        {
            //request
            CreateMap<FoodCategoryDTORequest, FoodCategory>();
            CreateMap<FoodCategory, FoodCategoryDTORequest>();

            //response
            CreateMap<FoodCategoryDTOResponse, FoodCategory>();
            CreateMap<FoodCategory, FoodCategoryDTOResponse>();

            //UpdateRequest
            CreateMap<FoodCategoryDTOUpdateRequest, FoodCategory>();
            CreateMap<FoodCategory, FoodCategoryDTOUpdateRequest>();

            //etc
        }
    }
}
