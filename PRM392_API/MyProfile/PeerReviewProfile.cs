using AutoMapper;
using PRM392_API.DTOs.PeerReview;
using PRM392_API.Models;

namespace PRM392_API.MyProfile
{
    public class PeerReviewProfile : Profile
    {
        public PeerReviewProfile()
        {
            CreateMap<PeerReview, PeerReviewDetailResponse>().
                ForMember(dest => dest.ReviewerName, opt => opt.MapFrom(src => src.Reviewer!.FirstName + " " + src.Reviewer.LastName));
            CreateMap<AddReviewRequest, PeerReview>();
        }
    }
}
