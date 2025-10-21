using AutoMapper;
using PRM392_API.DTOs.GroupTask;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;

namespace PRM392_API.Services.Implementation
{
    public class GroupTaskService : IGroupTaskService
    {
        private readonly IGroupTaskRepository _groupTaskRepository;
        private readonly IMapper _mapper;
        public GroupTaskService(IGroupTaskRepository groupTaskRepository, IMapper mapper)
        {
            _groupTaskRepository = groupTaskRepository;
            _mapper = mapper;
        }
        public Task<GroupTask> CreateGroupTask(GroupTask groupTask)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGroupTask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupTaskInAssignmentDetailResponse>> GetAllGroupTasks()
        {
            var groupTasks = await _groupTaskRepository.GetAllGroupTasks();
            return _mapper.Map<IEnumerable<GroupTaskInAssignmentDetailResponse>>(groupTasks);
        }

        public Task<GroupTask?> GetGroupTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupTask?> UpdateGroupTask(GroupTask groupTask)
        {
            throw new NotImplementedException();
        }
    }
}
