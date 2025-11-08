using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;
using PRM392_API.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PRM392_API.Services.Implementation
{
    public class StudentClassService : IStudentClassService
    {
        private readonly IStudentClassRepository _studentClassRepository;
        private readonly ITeacherClassRepository _classRepository; // Dùng để kiểm tra mã lớp

        public StudentClassService(IStudentClassRepository studentClassRepository, ITeacherClassRepository classRepository)
        {
            _studentClassRepository = studentClassRepository;
            _classRepository = classRepository;
        }

        public IEnumerable<StudentClassListDto> GetClassesByStudentId(int studentId)
        {
            var studentClasses = _studentClassRepository.GetClassesByStudentId(studentId);

            return studentClasses.Select(sc => new StudentClassListDto
            {
                StudentClassId = sc.Id,
                ClassId = sc.ClassId.GetValueOrDefault(),
                ClassName = sc.Class.ClassName,
                ClassCode = sc.Class.ClassCode,
                CourseName = sc.Class.Course.Name,
                TeacherFullName = $"{sc.Class.Teacher?.FirstName ?? ""} {sc.Class.Teacher?.LastName ?? ""}".Trim()
            }).ToList();
        }

        // CHỨC NĂNG 2: Xử lý logic tham gia lớp học
        public (bool success, string message) JoinClass(int studentId, string classCode)
        {

            var classToJoin = _classRepository.GetClassByCode(classCode);

            if (classToJoin == null)
            {
                return (false, "Mã lớp học không hợp lệ hoặc không tồn tại.");
            }

            if (_studentClassRepository.IsStudentInClass(studentId, classToJoin.ClassId))
            {
                return (false, "Bạn đã tham gia lớp học này rồi.");
            }

            var newStudentClass = new StudentClass
            {
                StudentId = studentId,
                ClassId = classToJoin.ClassId
            };

            _studentClassRepository.AddStudentToClass(newStudentClass);

            return (true, "Tham gia lớp học thành công! Vui lòng tải lại trang.");
        }
    }
}
