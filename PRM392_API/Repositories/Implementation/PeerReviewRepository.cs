using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class PeerReviewRepository : IPeerReviewRepository
    {
        private readonly PRM392Context _context;
        public PeerReviewRepository(PRM392Context context)
        {
            _context = context;
        }
        public async Task AddReviewAsync(PeerReview peerReview)
        {
           _context.PeerReviews.Add(peerReview);
            await _context.SaveChangesAsync();
        }

        public async Task<PeerReview?> GetPeerReviewByIdAsync(int reviewerId, int revieweeId, int assignmentId, int groupId)
        {
            return await _context.PeerReviews
                .Include(pr => pr.Reviewer)
                .FirstOrDefaultAsync(pr => pr.ReviewerId == reviewerId 
                                        && pr.RevieweeId == revieweeId 
                                        && pr.AssignmentId == assignmentId 
                                        && pr.GroupId == groupId);
        }

        public async Task UpdateReviewAsync(PeerReview peerReview)
        {
            _context.PeerReviews.Update(peerReview);
            await _context.SaveChangesAsync();
        }
    }
}
