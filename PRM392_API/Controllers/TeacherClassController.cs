using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        private readonly ITeacherClassService _classService;
        private readonly ICourseRepository _courseRepository;

        public TeacherClassController(ITeacherClassService classService, ICourseRepository courseRepository)
        {
            _classService = classService;
            _courseRepository = courseRepository;
        }
        [HttpGet("TeacherHome")]
        public async Task<IActionResult> TeacherHome([FromQuery]int teacherId)
        {
            // Giả định User ID = 101
            

            IEnumerable<ClassListViewModel> teacherClasses = _classService.GetClassesByTeacherId(teacherId);
            IEnumerable<Course> allCourses = _courseRepository.GetCoursesByTeacherId(teacherId);

            return Ok(new
            {
                TeacherId = teacherId,
                Classes = teacherClasses,
                AllCourses = allCourses.Select(c => new { c.Id, c.Name, c.Description })
            });
        }

        [HttpPost("/Class/Create")]
      
        public async Task<IActionResult> Create([FromBody] CreateClassViewModel model)
        {
            //User user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return Unauthorized(new { success = false, message = "Bạn cần đăng nhập để tạo lớp." });
            //}
            Console.WriteLine("-================================================="+model.TeacherId);
            
            var result = _classService.CreateNewClass(model);

            if (result.success)
            {
                return Ok(new { success = true, message = result.message });
            }

            return BadRequest(new { success = false, message = result.message });
        }


    }
}
