using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForMemberListDto>()
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge())
                )
                .ForMember(
                    dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url)
                );
            CreateMap<User, UserForMemberDetailDto>()
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge())
                );

            CreateMap<Photo, PhotoForMemberDetailDto>();
        }
    }
}
