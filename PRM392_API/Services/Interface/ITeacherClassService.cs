using PRM392_API.ViewModels;

namespace PRM392_API.Services.Interface
{
    public interface ITeacherClassService
    {
        IEnumerable<ClassListViewModel> GetClassesByTeacherId(int teacherId);
        (bool success, string message) CreateNewClass(CreateClassViewModel newClassModel);
    }
}
