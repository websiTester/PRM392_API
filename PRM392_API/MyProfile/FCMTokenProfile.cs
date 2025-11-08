using AutoMapper;

namespace PRM392_API.MyProfile
{
    public class FCMTokenProfile : Profile
    {
        public FCMTokenProfile()
        {
            CreateMap<DTOs.FCMToken.AddFCMTokenRequest, Models.FCMToken>()
                .ForMember(dest => dest.LastUpdated, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
