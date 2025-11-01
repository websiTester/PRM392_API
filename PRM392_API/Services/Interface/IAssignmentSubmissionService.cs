using PRM392_API.DTOs.AssignmentSubmission;

namespace PRM392_API.Services.Interface
{
    public interface IAssignmentSubmissionService
    {
        Task SubmitAssignment(SubmitRequest request);
        Task<SubmissionResponse?> GetSubmission(int assignmentId, int studentId);
        Task DeleteSubmission(int assignmentId, int studentId);
    }
}
