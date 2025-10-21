using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface ITeacherClassRepository
    {
        Class GetClassByCode(string classCode);

        IEnumerable<Class> GetClassesByTeacherId(int teacherId);
        void AddClass(Class newClass);
        bool IsClassCodeExist(string classCode);


    }
}
