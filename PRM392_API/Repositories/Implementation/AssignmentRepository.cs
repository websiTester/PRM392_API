using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly PRM392Context _context;
        public AssignmentRepository(PRM392Context context)
        {
            _context = context;
        }

        public async Task<Assignment> CreateAssignmentAsync(Assignment assignment)
        {
            assignment.CreatedAt = DateTime.UtcNow;
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task DeleteAssignmentAsync(int assignmentId)
        {
            var assignment = await _context.Assignments.FindAsync(assignmentId);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int assignmentId)
        {
            return await _context.Assignments.FindAsync(assignmentId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByClassIdAsync(int classId)
        {
            return await _context.Assignments
                .Where(a => a.ClassId == classId)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
            await _context.SaveChangesAsync();
        }
    }
}
