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
        public async Task CreateGroupTask(AddGroupTaskRequest addGroupTaskRequest)
        {
            try
            {
               var groupTask = _mapper.Map<GroupTask>(addGroupTaskRequest);
               await _groupTaskRepository.CreateGroupTask(groupTask);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the group task.", ex);
            }
        }
        public async Task<bool> DeleteGroupTask(int id)
        {
            try
            {
                return await _groupTaskRepository.DeleteGroupTask(id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the group task.", ex);
            }
        }

        public async Task<IEnumerable<GroupTaskInAssignmentDetailResponse>> GetAllGroupTasks(int assignmentId, int groupId)
        {
            var groupTasks = await _groupTaskRepository.GetAllGroupTasks(assignmentId, groupId);
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

        public async Task UpdateGroupTaskStatus(int taskId, bool isUp)
        {
            await _groupTaskRepository.UpdateGroupTaskStatus(taskId, isUp);
        }
    }
}
