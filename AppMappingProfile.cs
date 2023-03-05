using AutoMapper;
using social_network_API.Models;
using social_network_API.Models.DTO;

namespace social_network_API;

public class AppMappingProfile : Profile {
    public AppMappingProfile() {
        CreateMap<UserRegisterModel, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        CreateMap<User, UserProfile>();
    }
}