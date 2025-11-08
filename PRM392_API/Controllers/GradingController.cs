using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.DTOs.Grading;
using PRM392_API.Models;
using PRM392_API.Services.Interface;

namespace PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradingController : ControllerBase
    {
        private readonly IGradingService _gradingService;
        public GradingController(IGradingService gradingService)
        {
            _gradingService = gradingService;
        }
        [HttpGet]
        public IActionResult Get(int groupId, int assignmentId)
        {
            var grading = _gradingService.GetGradingDetails(groupId, assignmentId);
            return Ok(grading);
        }
        [HttpPost("save-group-grade")]
        public IActionResult SaveGroupGrade([FromBody] GradingViewModel model)
        {
            // Loại bỏ validation cho các field không gửi từ API
            ModelState.Remove(nameof(model.AssignmentName));
            ModelState.Remove(nameof(model.GroupName));
            ModelState.Remove(nameof(model.SubmissionLink));
            ModelState.Remove(nameof(model.Members));
            ModelState.Remove(nameof(model.GroupComment));

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();

                return BadRequest(new
                {
                    success = false,
                    message = "Dữ liệu không hợp lệ",
                    errors
                });
            }

            try
            {
                _gradingService.SaveGroupGrade(model);
                return Ok(new
                {
                    success = true,
                    message = "Đã lưu đánh giá chung thành công!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Đã xảy ra lỗi khi lưu đánh giá.",
                    detail = ex.Message
                });
            }
        }

        [HttpPost("save-member-grades")]
        public async Task<IActionResult> SaveMemberGrades([FromBody] GradingViewModel model, int teacherId)
        {
            
            //if (!int.TryParse(teacherIdString, out var teacherId))
            //{
            //    return Unauthorized(new
            //    {
            //        success = false,
            //        message = "ID giáo viên không hợp lệ."
            //    });
            //}

            //if (string.IsNullOrEmpty(teacherIdString))
            //{
            //    return Unauthorized(new
            //    {
            //        success = false,
            //        message = "Không xác định được giáo viên đang đăng nhập."
            //    });
            //}

            // Bỏ qua các trường không gửi từ API này
            ModelState.Remove(nameof(model.AssignmentName));
            ModelState.Remove(nameof(model.GroupName));
            ModelState.Remove(nameof(model.SubmissionLink));
            ModelState.Remove(nameof(model.GroupGrade));
            ModelState.Remove(nameof(model.GroupComment));

            if (model.Members != null)
            {
                for (int i = 0; i < model.Members.Count; i++)
                {
                    ModelState.Remove($"Members[{i}].FullName");
                    ModelState.Remove($"Members[{i}].Comment");
                }
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();

                return BadRequest(new
                {
                    success = false,
                    message = "Dữ liệu không hợp lệ",
                    errors
                });
            }

            try
            {
                _gradingService.SaveMemberGrades(model, teacherId);
                return Ok(new
                {
                    success = true,
                    message = "Đã lưu đánh giá thành viên thành công!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Đã xảy ra lỗi khi lưu đánh giá thành viên.",
                    detail = ex.Message
                });
            }
        }
    }
}
