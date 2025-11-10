using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.Services.Interface;

namespace PRM392_API.Controllers
{
    [Route("api/student-class-detail")]
    [ApiController]
    public class StudentClassDetailController : ControllerBase
    {
        // ID giả lập CỐ ĐỊNH cho Học sinh
        private const int MOCK_STUDENT_ID = 102;

        private readonly IClassDetailService _classService;

        public StudentClassDetailController(IClassDetailService classService)
        {
            _classService = classService;
        }

        // GET: api/student-class-detail/1
        [HttpGet("{classId}")]
        public async Task<IActionResult> GetClassDetail(int classId)
        {
            var vm = await _classService.GetClassDetailForStudentAsync(classId, MOCK_STUDENT_ID);
            if (vm == null) return NotFound(new { message = "Không tìm thấy lớp học." });
            return Ok(vm);
        }

        // POST: api/student-class-detail/groups/10/join
        [HttpPost("groups/{groupId}/join")]
        public async Task<IActionResult> JoinGroup(int groupId)
        {
            var result = await _classService.JoinGroupAsync(groupId, MOCK_STUDENT_ID);
            if (!result) return BadRequest(new { message = "Bạn đã ở trong nhóm khác." });
            return Ok(new { message = "Tham gia nhóm thành công." });
        }

        // POST: api/student-class-detail/groups/10/leave
        [HttpPost("groups/{groupId}/leave")]
        public async Task<IActionResult> LeaveGroup(int groupId)
        {
            await _classService.LeaveGroupAsync(groupId, MOCK_STUDENT_ID);
            return Ok(new { message = "Rời nhóm thành công." });
        }
    }
}
