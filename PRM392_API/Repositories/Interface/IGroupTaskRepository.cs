using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface IGroupTaskRepository
    {
        Task<IEnumerable<GroupTask>> GetAllGroupTasks(int assignmentId, int groupId);
        Task<GroupTask?> GetGroupTaskById(int id);
        Task CreateGroupTask(GroupTask groupTask);
        Task<GroupTask?> UpdateGroupTask(GroupTask groupTask);
        Task<bool> DeleteGroupTask(int id);
        Task UpdateGroupTaskStatus(int taskId, bool isUp);

    }
}
