using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.ViewModels.ClassDetails;

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

        public async Task<List<GroupGradeViewModel>> GetGroupGradesForAssignmentAsync(int assignmentId)
        {
            var assignment = await _context.Assignments
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(a => a.Id == assignmentId);

            if (assignment == null || assignment.ClassId == null)
            {
                return new List<GroupGradeViewModel>();
            }

            var classId = assignment.ClassId.Value;

            var groupGrades = await _context.Groups
                .Where(g => g.ClassId == classId)
                .Select(g => new GroupGradeViewModel
                {
                    GroupId = g.GroupId,

                    Grade = (float?)_context.AssignmentSubmissions
                        .Where(s =>
                            s.AssignmentId == assignmentId &&
                            s.TeacherGrade != null &&
                            _context.StudentGroups.Any(sg => sg.GroupId == g.GroupId && sg.StudentId == s.StudentId)
                        )
                        .Select(s => s.TeacherGrade)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return groupGrades;
        }

        public async Task<string> GetStudentGradeDisplayForAssignmentAsync(int assignmentId, int studentId)
        {
            var submission = await _context.AssignmentSubmissions
                .AsNoTracking()
                .FirstOrDefaultAsync(s =>
                    s.AssignmentId == assignmentId &&
                    s.StudentId == studentId
                );

            if (submission == null)
            {
                return "Chưa nộp bài";
            }

            if (submission.TeacherGrade == null)
            {
                return "Đã nộp (Chưa có điểm)";
            }

            return submission.TeacherGrade.Value.ToString("G29");
        }
    }
}
