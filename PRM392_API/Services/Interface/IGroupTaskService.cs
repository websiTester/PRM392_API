using PRM392_API.Models;

namespace PRM392_API.Services.Interface
{
    public interface IGroupTaskService
    {
        Task<IEnumerable<GroupTask>> GetAllGroupTasks();
        Task<GroupTask?> GetGroupTaskById(int id);
        Task<GroupTask> CreateGroupTask(GroupTask groupTask);
        Task<GroupTask?> UpdateGroupTask(GroupTask groupTask);
        Task<bool> DeleteGroupTask(int id);
    }
}
