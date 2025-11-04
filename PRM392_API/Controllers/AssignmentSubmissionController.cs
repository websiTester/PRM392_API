using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.DTOs.AssignmentSubmission;
using PRM392_API.Services.Interface;

namespace PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentSubmissionController : ControllerBase
    {
        private readonly IAssignmentSubmissionService _assignmentSubmissionService;
        public AssignmentSubmissionController(IAssignmentSubmissionService assignmentSubmissionService)
        {
            _assignmentSubmissionService = assignmentSubmissionService;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubmission([FromQuery] int assignmentId, [FromQuery] int studentId)
        {
            await _assignmentSubmissionService.DeleteSubmission(assignmentId,studentId);
            return NoContent();
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAssignment([FromBody] SubmitRequest request)
        {
            await _assignmentSubmissionService.SubmitAssignment(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int assignmentId, [FromQuery] int studentId)
        {
            var submission = await _assignmentSubmissionService.GetSubmission(assignmentId, studentId);
            if (submission == null)
            {
                return NotFound("Not found");
            }
            return Ok(submission);
        }

    }
}
