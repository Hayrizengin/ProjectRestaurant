using AutoMapper;
using ProjectRestaurant.Entity.DTO.LoginDTO;
using ProjectRestaurant.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.DTOMapper.LoginDTOMapper
{
    public class LoginDTOMap:Profile
    {
        public LoginDTOMap()
        {
            //request
            CreateMap<User, LoginDTORequest>().
                ForMember(dest => dest.Email, opt =>
                {
                    opt.MapFrom(src => src.Email);
                }).
                ForMember(dest => dest.Password, opt =>
                {
                    opt.MapFrom(src=>src.Password);
                }).ReverseMap();

            //response
            CreateMap<User, LoginDTOResponse>().
                ForMember(dest => dest.FirstName, opt =>
                {
                    opt.MapFrom(src => src.FirstName);
                }).
                ForMember(dest => dest.LastName, opt =>
                {
                    opt.MapFrom(src => src.LastName);
                }).
                ForMember(dest => dest.FullName, opt =>
                {
                    opt.MapFrom(src => src.FullName);
                }).
                ForMember(dest => dest.PhoneNumber, opt =>
                {
                    opt.MapFrom(src => src.PhoneNumber);
                }).
                ForMember(dest => dest.Email, opt =>
                {
                    opt.MapFrom(src => src.Email);
                }).
                ForMember(dest => dest.Guid, opt =>
                {
                    opt.MapFrom(src => src.Guid);
                }).ReverseMap();

            //etc
        }
    }
}
