using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface IClassDetailRepository
    {
        Task<Class> GetClassByIdAsync(int classId);
        Task<IEnumerable<User>> GetStudentsByClassIdAsync(int classId);
        Task<User> GetTeacherByClassIdAsync(int classId);
        Task<bool> IsUserTeacherOfClassAsync(int classId, int userId);
        Task<bool> IsUserStudentOfClassAsync(int classId, int userId);
    }
}
