using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetAssignmentsByClassIdAsync(int classId);
        Task<Assignment> GetAssignmentByIdAsync(int assignmentId);
        Task<Assignment> CreateAssignmentAsync(Assignment assignment);
        Task UpdateAssignmentAsync(Assignment assignment);
        Task DeleteAssignmentAsync(int assignmentId);
    }
}
