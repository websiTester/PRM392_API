using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.Models;
using PRM392_API.RequestModel;
using PRM392_API.Services.Implementation;
using PRM392_API.Services.Interface;

namespace PRM392_API.Controllers
{
    [Route("api/teacher-class-detail")]
    [ApiController]
    public class TeacherClassDetailController : ControllerBase
    {
        // ID giả lập CỐ ĐỊNH cho Giáo viên
        private const int MOCK_TEACHER_ID = 101;

        private readonly IClassDetailService _classDetailService;
        private readonly FirebaseMessaging _firebaseMessaging;
        private readonly IClassService _classService;
        private readonly IFCMTokenService _fCMTokenService;

        public TeacherClassDetailController(IClassDetailService classDetailService, FirebaseMessaging firebaseMessaging, IClassService classService, IFCMTokenService fCMTokenService)
        {
            _classDetailService = classDetailService;
            _firebaseMessaging = firebaseMessaging;
            _classService = classService;
            _fCMTokenService = fCMTokenService;
        }

        // GET: api/teacher-class-detail/1
        [HttpGet("{classId}")]
        public async Task<IActionResult> GetClassDetail(int classId)
        {
            var vm = await _classDetailService.GetClassDetailForTeacherAsync(classId, MOCK_TEACHER_ID);
            if (vm == null) return NotFound(new { message = "Không tìm thấy lớp học." });
            return Ok(vm);
        }

        // POST: api/teacher-class-detail/1/assignments
        [HttpPost("{classId}/assignments")]
        public async Task<IActionResult> CreateAssignment(int classId, [FromBody] CreateAssignmentRequest request)
        {

            var newAssignment = await _classDetailService.CreateAssignmentAsync(classId, request);
            await sendNotification(classId);
            return Ok(newAssignment);
        }

        // PUT: api/teacher-class-detail/assignments/5
        [HttpPut("assignments/{assignmentId}")]
        public async Task<IActionResult> UpdateAssignment(int assignmentId, [FromBody] CreateAssignmentRequest request)
        {
            var result = await _classDetailService.UpdateAssignmentAsync(assignmentId, request);
            if (!result) return NotFound(new { message = "Không tìm thấy bài tập." });
            return Ok(new { message = "Cập nhật thành công." });
        }

        // DELETE: api/teacher-class-detail/assignments/5
        [HttpDelete("assignments/{assignmentId}")]
        public async Task<IActionResult> DeleteAssignment(int assignmentId)
        {
            await _classDetailService.DeleteAssignmentAsync(assignmentId);
            return Ok(new { message = "Xóa thành công." });
        }

        // POST: api/teacher-class-detail/1/groups
        [HttpPost("{classId}/groups")]
        public async Task<IActionResult> CreateGroup(int classId, [FromBody] CreateGroupRequest request)
        {
            var newGroup = await _classDetailService.CreateGroupAsync(classId, request);
            return Ok(newGroup);
        }

        // DELETE: api/teacher-class-detail/groups/10
        [HttpDelete("groups/{groupId}")]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            await _classDetailService.DeleteGroupAsync(groupId);
            return Ok(new { message = "Xóa nhóm thành công." });
        }

        // POST: api/teacher-class-detail/groups/10/members
        [HttpPost("groups/{groupId}/members")]
        public async Task<IActionResult> AddStudentToGroup(int groupId, [FromBody] AddMemberToGroupRequest request)
        {
            var result = await _classDetailService.AddStudentToGroupAsync(groupId, request.StudentId);
            if (!result) return BadRequest(new { message = "Học sinh đã ở trong nhóm khác." });
            return Ok(new { message = "Thêm học sinh thành công." });
        }

        // DELETE: api/teacher-class-detail/groups/10/members/20
        [HttpDelete("groups/{groupId}/members/{studentId}")]
        public async Task<IActionResult> RemoveStudentFromGroup(int groupId, int studentId)
        {
            await _classDetailService.RemoveStudentFromGroupAsync(groupId, studentId);
            return Ok(new { message = "Xóa học sinh khỏi nhóm thành công." });
        }

        private async Task<bool> sendNotification(int classId)
        {
            var fcmTokens = await _fCMTokenService.GetTokensFromFirebaseAsync(classId);
            if (fcmTokens == null)
            {
                Console.WriteLine("No valid FCM tokens found for these students.");
                return false;
            }

            if (!fcmTokens.Any())
            {
                Console.WriteLine("No valid FCM tokens found for these students.");
                return false;
            }
            var message = new MulticastMessage()
            {
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Title = "Bạn có bài tập mới!",
                    Body = "Admin vừa thêm bài tập"
                },
                Tokens = fcmTokens.ToList(),
            };

            try
            {
                BatchResponse response = await _firebaseMessaging.SendEachForMulticastAsync(message);
                if (response.FailureCount > 0)
                {
                    var failedTokens = new List<string>();
                    for (int i = 0; i < response.Responses.Count; i++)
                    {
                        if (!response.Responses[i].IsSuccess)
                        {
                            failedTokens.Add(fcmTokens.ToList()[i]);
                        }
                    }
                    Console.WriteLine("Failed tokens: " + string.Join(", ", failedTokens));
                }

                return true;
            }
            catch (FirebaseMessagingException ex)
            {
                Console.WriteLine("Error sending multicast message: " + ex.Message);
                return false;
            }
        }
    }
    
}
