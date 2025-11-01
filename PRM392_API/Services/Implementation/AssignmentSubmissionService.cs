using AutoMapper;
using PRM392_API.DTOs.AssignmentSubmission;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;

namespace PRM392_API.Services.Implementation
{
    public class AssignmentSubmissionService : IAssignmentSubmissionService
    {
        private readonly IAssignmentSubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public AssignmentSubmissionService(IAssignmentSubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository;
            _mapper = mapper;
        }
        public async Task DeleteSubmission(int assignmentId, int studentId)
        {
            var submission = await _submissionRepository.GetAssignmentSubmission(assignmentId, studentId);
            if (submission != null)
            {
                await _submissionRepository.DeleteAssignmentSubmission(submission.SubmissionId);
            }
        }

        public async Task<SubmissionResponse?> GetSubmission(int assignmentId, int studentId)
        {
            var submission = await _submissionRepository.GetAssignmentSubmission(assignmentId, studentId);
            return _mapper.Map<SubmissionResponse?>(submission);
        }

        public async Task SubmitAssignment(SubmitRequest request)
        {
            var submissionEntity = _mapper.Map<AssignmentSubmission>(request);
            await _submissionRepository.AddAssignmentSubmission(submissionEntity);
        }
    }
}
