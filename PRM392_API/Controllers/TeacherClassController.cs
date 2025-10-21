using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Interface;
using PRM392_API.ViewModels;

namespace PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherClassController : ControllerBase
    {
        private const int MOCK_TEACHER_ID = 101;

        private readonly ITeacherClassService _classService;
        private readonly ICourseRepository _courseRepository;

        public TeacherClassController(ITeacherClassService classService, ICourseRepository courseRepository)
        {
            _classService = classService;
            _courseRepository = courseRepository;
        }
        [HttpGet("TeacherHome")]
        public async Task<IActionResult> TeacherHome()
        {
            // Giả định User ID = 101
            int teacherId = MOCK_TEACHER_ID;

            IEnumerable<ClassListViewModel> teacherClasses = _classService.GetClassesByTeacherId(teacherId);
            IEnumerable<Course> allCourses = _courseRepository.GetCoursesByTeacherId(teacherId);

            return Ok(new
            {
                TeacherId = teacherId,
                Classes = teacherClasses,
                AllCourses = allCourses.Select(c => new { c.Id, c.Name, c.Description })
            });
        }



    }
}
