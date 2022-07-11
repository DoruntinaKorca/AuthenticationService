using System;
using AuthenticationService.DTOs;
using AuthenticationService.Models;
using AutoMapper;

namespace AuthenticationService.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserPublishedDto, User>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash,
                opt => opt.MapFrom(src => src.Password));

            CreateMap<User, UserPublishedDto>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password,
                opt => opt.MapFrom(src => src.PasswordHash));
        }
    }
}