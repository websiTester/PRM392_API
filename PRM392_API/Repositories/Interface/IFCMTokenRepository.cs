using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface IFCMTokenRepository
    {
        Task AddOrUpdateTokenAsync(FCMToken fCMToken);
        Task<IEnumerable<FCMToken>> GetTokensByUserIdAsync(int[] userIds);
    }
}
