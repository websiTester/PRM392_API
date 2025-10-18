using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class GroupTaskRepository : IGroupTaskRepository
    {
        private readonly PRM392Context _context;
        public GroupTaskRepository(PRM392Context context)
        {
            _context = context;
        }
        public Task<GroupTask> CreateGroupTask(GroupTask groupTask)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGroupTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupTask>> GetAllGroupTasks()
        {
            throw new NotImplementedException();
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
