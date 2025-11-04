using PRM392_API.DTOs.PeerReview;

namespace PRM392_API.Services.Interface
{
    public interface IPeerReviewService
    {
        Task<PeerReviewDetailResponse?> GetPeerReviewByIdAsync(int reviewerId, int revieweeId, int assignmentId, int groupId);
        Task AddPeerReviewAsync(AddReviewRequest request);
        Task UpdatePeerReviewAsync(AddReviewRequest request);
    }
}
