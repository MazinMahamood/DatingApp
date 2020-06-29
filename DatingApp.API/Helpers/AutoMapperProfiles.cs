using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(src => src.PhotoUrl, opt => 
                    opt.MapFrom(dest => dest.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(src => src.Age, opt =>
                    opt.MapFrom(dest => dest.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailedDto>()
             .ForMember(src => src.PhotoUrl, opt => 
                    opt.MapFrom(dest => dest.Photos.FirstOrDefault(p => p.IsMain).Url))                    
                .ForMember(src => src.Age, opt =>
                    opt.MapFrom(dest => dest.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}