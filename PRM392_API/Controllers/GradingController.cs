using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
