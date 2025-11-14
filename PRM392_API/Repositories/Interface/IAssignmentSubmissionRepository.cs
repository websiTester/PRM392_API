using PRM392_API.Models;
using PRM392_API.ViewModels.ClassDetails;

namespace PRM392_API.Repositories.Interface
{
    public interface IAssignmentSubmissionRepository
    {
        Task<AssignmentSubmission?> GetAssignmentSubmission(int assignmentId, int studentId);
        Task AddAssignmentSubmission(AssignmentSubmission submission);
        Task DeleteAssignmentSubmission(int submissionId);
        Task<List<GroupGradeViewModel>> GetGroupGradesForAssignmentAsync(int assignmentId);
        Task<string> GetStudentGradeDisplayForAssignmentAsync(int assignmentId, int studentId);
    }
}
