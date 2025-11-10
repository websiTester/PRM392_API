using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.RequestModel;
using PRM392_API.Services.Interface;

namespace PRM392_API.Controllers
{
    [Route("api/teacher-class-detail")]
    [ApiController]
    public class TeacherClassDetailController : ControllerBase
    {
        // ID giả lập CỐ ĐỊNH cho Giáo viên
        private const int MOCK_TEACHER_ID = 101;

        private readonly IClassDetailService _classService;

        public TeacherClassDetailController(IClassDetailService classService)
        {
            _classService = classService;
        }

        // GET: api/teacher-class-detail/1
        [HttpGet("{classId}")]
        public async Task<IActionResult> GetClassDetail(int classId)
        {
            var vm = await _classService.GetClassDetailForTeacherAsync(classId, MOCK_TEACHER_ID);
            if (vm == null) return NotFound(new { message = "Không tìm thấy lớp học." });
            return Ok(vm);
        }

        // POST: api/teacher-class-detail/1/assignments
        [HttpPost("{classId}/assignments")]
        public async Task<IActionResult> CreateAssignment(int classId, [FromBody] CreateAssignmentRequest request)
        {
            var newAssignment = await _classService.CreateAssignmentAsync(classId, request);
            return Ok(newAssignment);
        }

        // PUT: api/teacher-class-detail/assignments/5
        [HttpPut("assignments/{assignmentId}")]
        public async Task<IActionResult> UpdateAssignment(int assignmentId, [FromBody] CreateAssignmentRequest request)
        {
            var result = await _classService.UpdateAssignmentAsync(assignmentId, request);
            if (!result) return NotFound(new { message = "Không tìm thấy bài tập." });
            return Ok(new { message = "Cập nhật thành công." });
        }

        // DELETE: api/teacher-class-detail/assignments/5
        [HttpDelete("assignments/{assignmentId}")]
        public async Task<IActionResult> DeleteAssignment(int assignmentId)
        {
            await _classService.DeleteAssignmentAsync(assignmentId);
            return Ok(new { message = "Xóa thành công." });
        }

        // POST: api/teacher-class-detail/1/groups
        [HttpPost("{classId}/groups")]
        public async Task<IActionResult> CreateGroup(int classId, [FromBody] CreateGroupRequest request)
        {
            var newGroup = await _classService.CreateGroupAsync(classId, request);
            return Ok(newGroup);
        }

        // DELETE: api/teacher-class-detail/groups/10
        [HttpDelete("groups/{groupId}")]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            await _classService.DeleteGroupAsync(groupId);
            return Ok(new { message = "Xóa nhóm thành công." });
        }

        // POST: api/teacher-class-detail/groups/10/members
        [HttpPost("groups/{groupId}/members")]
        public async Task<IActionResult> AddStudentToGroup(int groupId, [FromBody] AddMemberToGroupRequest request)
        {
            var result = await _classService.AddStudentToGroupAsync(groupId, request.StudentId);
            if (!result) return BadRequest(new { message = "Học sinh đã ở trong nhóm khác." });
            return Ok(new { message = "Thêm học sinh thành công." });
        }

        // DELETE: api/teacher-class-detail/groups/10/members/20
        [HttpDelete("groups/{groupId}/members/{studentId}")]
        public async Task<IActionResult> RemoveStudentFromGroup(int groupId, int studentId)
        {
            await _classService.RemoveStudentFromGroupAsync(groupId, studentId);
            return Ok(new { message = "Xóa học sinh khỏi nhóm thành công." });
        }

    }
}
