using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;
using PRM392_API.ViewModels;

namespace PRM392_API.Services.Implementation
{
    public class TeacherClassService : ITeacherClassService
    {
        ITeacherClassRepository _teacherClassRepository;

        public TeacherClassService(ITeacherClassRepository teacherClassRepository)
        {
            _teacherClassRepository = teacherClassRepository;
        }

        public (bool success, string message) CreateNewClass(CreateClassViewModel newClassModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClassListViewModel> GetClassesByTeacherId(int teacherId)
        {
            var classes = _teacherClassRepository.GetClassesByTeacherId(teacherId);


            return classes.Select(c => new ClassListViewModel
            {
                ClassId = c.ClassId,
                ClassName = c.ClassName,
                ClassCode = c.ClassCode,
                CourseName = c.Course.Name,
                TeacherFullName = $"{c.Teacher.FirstName} {c.Teacher.LastName}"
            }).ToList();
        }
    }
}
