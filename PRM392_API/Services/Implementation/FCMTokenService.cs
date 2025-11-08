using AutoMapper;
using PRM392_API.DTOs.FCMToken;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;

namespace PRM392_API.Services.Implementation
{
    public class FCMTokenService : IFCMTokenService
    {
        private readonly IFCMTokenRepository _fcmTokenRepository;
        private readonly IMapper _mapper;
        public FCMTokenService(IFCMTokenRepository fcmTokenRepository, IMapper mapper)
        {
            _fcmTokenRepository = fcmTokenRepository;
            _mapper = mapper;
        }

        public async Task SaveTokenAsync(AddFCMTokenRequest addFCMTokenRequest)
        {
           var fcmToken = _mapper.Map<Models.FCMToken>(addFCMTokenRequest);
            await _fcmTokenRepository.AddOrUpdateTokenAsync(fcmToken);
        }
    }
}
