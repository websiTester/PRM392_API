using PRM392_API.DTOs.Grading;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;

namespace PRM392_API.Services.Implementation
{
    public class GradingService : IGradingService
    {
        private readonly IGradingRepository _repository;
        public GradingService(IGradingRepository repository)
        {
            _repository = repository;
        }

        public GradingViewModel GetGradingDetails(int groupId, int assignmentId)
        {
            return _repository.GetGradingDetails(groupId, assignmentId);
        }

        public AssignmentSubmission GetSubmissionLink(int assignmentId, int groupId)
        {
            return _repository.GetSubmissionLink(assignmentId, groupId);
        }

        public void SaveGroupGrade(GradingViewModel viewModel)
        {
            _repository.SaveGroupGrade(viewModel);
        }

        public void SaveMemberGrades(GradingViewModel viewModel, int teacherId)
        {
            _repository.SaveMemberGrades(viewModel, teacherId);
        }
    }
}
