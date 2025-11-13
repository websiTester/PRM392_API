using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.Services.Interface;
using PRM392_API.RequestModel;

namespace PRM392_API.Controllers
{
    [Route("api/student-class-detail")]
    [ApiController]
    public class StudentClassDetailController : ControllerBase
    {
        // private const int MOCK_STUDENT_ID = 102;

        private readonly IClassDetailService _classService;

        public StudentClassDetailController(IClassDetailService classService)
        {
            _classService = classService;
        }

        [HttpGet("{classId}")]
        public async Task<IActionResult> GetClassDetail(int classId, [FromQuery] int userId)
        {
            var vm = await _classService.GetClassDetailForStudentAsync(classId, userId);
            if (vm == null) return NotFound(new { message = "Không tìm thấy lớp học." });
            return Ok(vm);
        }

        [HttpPost("groups/{groupId}/join")]
        public async Task<IActionResult> JoinGroup(int groupId, [FromBody] StudentGroupActionRequest request)
        {
            var result = await _classService.JoinGroupAsync(groupId, request.UserId);
            if (!result) return BadRequest(new { message = "Bạn đã ở trong nhóm khác." });
            return Ok(new { message = "Tham gia nhóm thành công." });
        }

        [HttpPost("groups/{groupId}/leave")]
        public async Task<IActionResult> LeaveGroup(int groupId, [FromBody] StudentGroupActionRequest request)
        {
            await _classService.LeaveGroupAsync(groupId, request.UserId);
            return Ok(new { message = "Rời nhóm thành công." });
        }
    }
}