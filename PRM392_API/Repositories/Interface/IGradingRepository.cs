using PRM392_API.DTOs.Grading;
using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface IGradingRepository
    {
        GradingViewModel GetGradingDetails(int groupId, int assignmentId);
        void SaveGroupGrade(GradingViewModel viewModel);
        void SaveMemberGrades(GradingViewModel viewModel, int teacherId);
        AssignmentSubmission GetSubmissionLink(int assignmentId, int groupId);
    }
}
