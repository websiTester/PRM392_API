using AutoMapper;
using PRM392_API.DTOs.User;
using PRM392_API.Models;

namespace PRM392_API.MyProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserForDropdownResponse>();
        }
    }
}
