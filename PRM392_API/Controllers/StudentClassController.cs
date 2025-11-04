
using Microsoft.AspNetCore.Mvc;
using PRM392_API.Services.Interface;
using PRM392_API.ViewModels;

namespace PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentClassController : ControllerBase
    {
        private readonly IStudentClassService _studentClassService;
        //private readonly UserManager<User> _userManager;

        public StudentClassController(IStudentClassService studentClassService)
        {
            _studentClassService = studentClassService;
            //_userManager = userManager;
        }

        [HttpGet("GetClasses")]
        public async Task<IActionResult> GetClasses()
        {
            //User user = await _userManager.GetUserAsync(User);

            //if (user == null)
            //{
            //    return Unauthorized(new { success = false, message = "Bạn cần đăng nhập để xem lớp học." });
            //}



            int currentUserId = 107;

            IEnumerable<StudentClassListDto> studentClasses = _studentClassService.GetClassesByStudentId(currentUserId);

            return Ok(studentClasses);
        }

     
        [HttpPost("Join")]
        public async Task<IActionResult> JoinClass([FromBody] JoinClassViewModel model)
        {
            //User user = await _userManager.GetUserAsync(User);

            //if (user == null)
            //{
            //    return Unauthorized(new { success = false, message = "Bạn cần đăng nhập để tham gia lớp." });
            //}

            var result = _studentClassService.JoinClass(107, model.ClassCode);

            if (result.success)
            {
                return Ok(new { success = true, message = result.message });
            }

            return BadRequest(new { success = false, message = result.message });
        }
    }
}
