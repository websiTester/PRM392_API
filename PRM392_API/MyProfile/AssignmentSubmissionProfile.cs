using AutoMapper;
using PRM392_API.DTOs.AssignmentSubmission;
using PRM392_API.Models;

namespace PRM392_API.MyProfile
{
    public class AssignmentSubmissionProfile : Profile
    {
        public AssignmentSubmissionProfile()
        {
            CreateMap<AssignmentSubmission, SubmissionResponse>()
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student!.FirstName + " " + src.Student.LastName))
                .ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => src.SubmittedAt != null ? src.SubmittedAt.Value.ToString("yyyy-MM-dd") : null));
            CreateMap<SubmitRequest, AssignmentSubmission>().
                ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
