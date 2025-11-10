using PRM392_API.DTOs.FCMToken;
using PRM392_API.Migrations;
using PRM392_API.Models;

namespace PRM392_API.Services.Interface
{
    public interface IFCMTokenService
    {
        Task SaveTokenAsync(AddFCMTokenRequest addFCMTokenRequest);
        Task<IEnumerable<string>?> GetTokensFromFirebaseAsync(int classId);
        Task<List<int?>> GetClassByUserId(int userId);
        Task<IEnumerable<Assignment>> GetAssignmentsNearingDeadline(TimeSpan timeSpan);
    }
}
