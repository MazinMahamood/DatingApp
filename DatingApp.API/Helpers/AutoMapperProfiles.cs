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
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(src => src.SenderPhotoUrl, opt => 
                    opt.MapFrom(dest => dest.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(src => src.RecipientPhotoUrl, 
                    opt => opt.MapFrom(dest => dest.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
            
        }
    }
}