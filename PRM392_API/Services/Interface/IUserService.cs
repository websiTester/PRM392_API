using PRM392_API.DTOs.User;

namespace PRM392_API.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserForDropdownResponse>> GetUsersByGroupId(int groupId);
    }
}
