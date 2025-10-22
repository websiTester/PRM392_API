using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUserInGroup(int groupId);
    }
}
