using AutoMapper;
using PRM392_API.DTOs.User;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;

namespace PRM392_API.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetUserForDropdownResponse>> GetUsersByGroupId(int groupId)
        {
            var users = await _userRepository.GetUserInGroup(groupId);
            return _mapper.Map<IEnumerable<GetUserForDropdownResponse>>(users);
        }
    }
}
