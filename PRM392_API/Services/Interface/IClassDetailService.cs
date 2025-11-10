using PRM392_API.RequestModel;
using PRM392_API.ViewModels.ClassDetails;

namespace PRM392_API.Services.Interface
{
    public interface IClassDetailService
    {
        Task<ClassDetailStudentViewModel> GetClassDetailForStudentAsync(int classId, int studentId);
        Task<ClassDetailTeacherViewModel> GetClassDetailForTeacherAsync(int classId, int teacherId);
        Task<bool> IsUserTeacherOfClassAsync(int classId, int userId);
        Task<AssignmentViewModel> CreateAssignmentAsync(int classId, CreateAssignmentRequest request);
        Task<bool> UpdateAssignmentAsync(int assignmentId, CreateAssignmentRequest request);
        Task<bool> DeleteAssignmentAsync(int assignmentId);
        Task<GroupViewModel> CreateGroupAsync(int classId, CreateGroupRequest request);
        Task<bool> DeleteGroupAsync(int groupId);
        Task<bool> AddStudentToGroupAsync(int groupId, int studentId);
        Task<bool> RemoveStudentFromGroupAsync(int groupId, int studentId);
        Task<bool> JoinGroupAsync(int groupId, int studentId);
        Task<bool> LeaveGroupAsync(int groupId, int studentId);
    }
}
