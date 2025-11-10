using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetGroupsByClassIdAsync(int classId);
        Task<Group> GetGroupByIdAsync(int groupId);
        Task<IEnumerable<User>> GetMembersByGroupIdAsync(int groupId);
        Task<Group> GetStudentGroupInClassAsync(int classId, int studentId);
        Task<Group> CreateGroupAsync(Group group);
        Task DeleteGroupAsync(int groupId);
        Task AddStudentToGroupAsync(int groupId, int studentId);
        Task RemoveStudentFromGroupAsync(int groupId, int studentId);
        Task<IEnumerable<Group>> GetGroupsByClassIdWithMembersAsync(int classId);
    }
}
