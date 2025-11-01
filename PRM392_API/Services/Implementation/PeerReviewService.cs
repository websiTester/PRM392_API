using AutoMapper;
using PRM392_API.DTOs.PeerReview;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;

namespace PRM392_API.Services.Implementation
{
    public class PeerReviewService : IPeerReviewService
    {
        private readonly IPeerReviewRepository _peerReviewRepository;
        private readonly IMapper _mapper;
        public PeerReviewService(IPeerReviewRepository peerReviewRepository, IMapper mapper)
        {
            _peerReviewRepository = peerReviewRepository;
            _mapper = mapper;
        }
        public async Task AddPeerReviewAsync(AddReviewRequest request)
        {
            var peerReview = _mapper.Map<AddReviewRequest, PeerReview>(request);
            await _peerReviewRepository.AddReviewAsync(peerReview);
        }

        public async Task<PeerReviewDetailResponse?> GetPeerReviewByIdAsync(int reviewerId, int revieweeId, int assignmentId, int groupId)
        {
            var peerReview = await _peerReviewRepository.GetPeerReviewByIdAsync(reviewerId, revieweeId, assignmentId, groupId);
            if (peerReview == null)
            {
                return null;
            }
            var response = _mapper.Map<PeerReview, PeerReviewDetailResponse>(peerReview);
            return response;
        }

        public async Task UpdatePeerReviewAsync(AddReviewRequest request)
        {
            var peerReview = _mapper.Map<AddReviewRequest, PeerReview>(request);
            await _peerReviewRepository.UpdateReviewAsync(peerReview);
        }
    }
}
