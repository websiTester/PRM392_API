using AutoMapper;
using PRM392_API.DTOs.GroupTask;
using PRM392_API.Models;

namespace PRM392_API.MyProfile
{
    public class GroupTaskProfile : Profile
    {
        public GroupTaskProfile()
        {
            CreateMap<GroupTask, GroupTaskInAssignmentDetailResponse>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.Points ?? 0))
                .ForMember(dest => dest.AssignedToName, opt => opt.MapFrom(src => src.AssignedToNavigation != null ? src.AssignedToNavigation.FirstName +" "+ src.AssignedToNavigation.LastName : "Unassigned"))
                .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Group != null ? src.Group.StudentGroups.Select(gm => gm.Student!=null? new SimpleUser
                {
                    Id = gm.Student.UserId,
                    FirstName = gm.Student.FirstName,
                    LastName = gm.Student.LastName,
                } : new SimpleUser()).ToList() : new List<SimpleUser>()));


            CreateMap<AddGroupTaskRequest, GroupTask>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "todo"))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
