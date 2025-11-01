using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class AssignmentSubmissionRepository : IAssignmentSubmissionRepository
    {
        private readonly PRM392Context _context;
        public AssignmentSubmissionRepository(PRM392Context context)
        {
            _context = context;
        }
        public async Task AddAssignmentSubmission(AssignmentSubmission submission)
        {
            _context.AssignmentSubmissions.Add(submission);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssignmentSubmission(int submissionId)
        {
            _context.AssignmentSubmissions.Remove(_context.AssignmentSubmissions.Find(submissionId)!);
            await _context.SaveChangesAsync();
        }

        public async Task<AssignmentSubmission?> GetAssignmentSubmission(int assignmentId, int studentId)
        {
            return await _context.AssignmentSubmissions
                .Include(a =>a.Student)
                .Where(a => a.AssignmentId == assignmentId && a.StudentId == studentId)
                .FirstOrDefaultAsync();
        }
    }
}
