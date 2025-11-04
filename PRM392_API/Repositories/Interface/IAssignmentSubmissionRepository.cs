using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface IAssignmentSubmissionRepository
    {
        Task<AssignmentSubmission?> GetAssignmentSubmission(int assignmentId, int studentId);
        Task AddAssignmentSubmission(AssignmentSubmission submission);
        Task DeleteAssignmentSubmission(int submissionId);
    }
}
