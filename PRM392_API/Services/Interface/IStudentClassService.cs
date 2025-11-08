using PRM392_API.ViewModels;

namespace PRM392_API.Services.Interface
{
    public interface IStudentClassService
    {
        IEnumerable<StudentClassListDto> GetClassesByStudentId(int studentId);
        (bool success, string message) JoinClass(int studentId, string classCode);
    }
}
