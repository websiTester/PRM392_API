using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface IPeerReviewRepository
    {
        Task<PeerReview?> GetPeerReviewByIdAsync(int reviewerId, int revieweeId, int assignmentId, int groupId);
        Task AddReviewAsync(PeerReview peerReview);
        Task UpdateReviewAsync(PeerReview peerReview);
    }
}
