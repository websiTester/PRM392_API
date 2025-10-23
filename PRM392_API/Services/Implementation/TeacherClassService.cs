using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;
using PRM392_API.ViewModels;
using System;

namespace PRM392_API.Services.Implementation
{
    public class TeacherClassService : ITeacherClassService
    {
        ITeacherClassRepository _teacherClassRepository;
        private static Random random = new Random();
        private readonly ICourseRepository _courseRepository;

        public TeacherClassService(ITeacherClassRepository teacherClassRepository, ICourseRepository courseRepository)
        {
            _teacherClassRepository = teacherClassRepository;
            _courseRepository = courseRepository;
        }

        public (bool success, string message) CreateNewClass(CreateClassViewModel newClassModel)
        {
            int courseId = newClassModel.ExistingCourseId ?? 0;
            if (newClassModel.IsNewCourse && !string.IsNullOrEmpty(newClassModel.NewCourseName))
            {
                if (_courseRepository.IsCourseNameExist(newClassModel.NewCourseName, newClassModel.TeacherId))
                {
                    return (false, "Tên khóa học đã tồn tại.");
                }
                var newCourse = new Course
                {
                    Name = newClassModel.NewCourseName,
                    Description = newClassModel.NewCourseDescription,
                    CreateBy = newClassModel.TeacherId,
                    CreateAt = DateTime.Now
                };
                _courseRepository.AddCourse(newCourse);
                courseId = newCourse.Id;
            }

            // Tạo ClassCode ngẫu nhiên
            string classCode = GenerateRandomClassCode();
            while (_teacherClassRepository.IsClassCodeExist(classCode))
            {
                classCode = GenerateRandomClassCode();
            }

            // Tạo Class mới
            var newClass = new Models.Class
            {
                ClassName = newClassModel.ClassName,
                ClassCode = classCode,
                CreatedAt = DateTime.Now,
                CourseId = courseId,
                TeacherId = newClassModel.TeacherId
            };

            _teacherClassRepository.AddClass(newClass);

            return (true, "Tạo lớp học thành công!");
        }


        private string GenerateRandomClassCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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
