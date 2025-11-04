using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface IStudentClassRepository
    {
        IEnumerable<StudentClass> GetClassesByStudentId(int studentId);
        bool IsStudentInClass(int studentId, int classId);
        void AddStudentToClass(StudentClass studentClass);
    }
}
