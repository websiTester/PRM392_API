using PRM392_API.DTOs.GroupTask;
using PRM392_API.Models;

namespace PRM392_API.Services.Interface
{
    public interface IGroupTaskService
    {
        Task<IEnumerable<GroupTaskInAssignmentDetailResponse>> GetAllGroupTasks(int assigmentId, int groupId);
        Task<GroupTask?> GetGroupTaskById(int id);
        Task CreateGroupTask(AddGroupTaskRequest addGroupTaskRequest);
        Task<GroupTask?> UpdateGroupTask(GroupTask groupTask);
        Task<bool> DeleteGroupTask(int id);
        Task UpdateGroupTaskStatus(int taskId);
    }
}
