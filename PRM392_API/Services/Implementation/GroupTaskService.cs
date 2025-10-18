using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;

namespace PRM392_API.Services.Implementation
{
    public class GroupTaskService : IGroupTaskService
    {
        private readonly IGroupTaskRepository _groupTaskRepository;
        public GroupTaskService(IGroupTaskRepository groupTaskRepository)
        {
            _groupTaskRepository = groupTaskRepository;
        }
        public Task<GroupTask> CreateGroupTask(GroupTask groupTask)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGroupTask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupTask>> GetAllGroupTasks()
        {
            return await _groupTaskRepository.GetAllGroupTasks();
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
