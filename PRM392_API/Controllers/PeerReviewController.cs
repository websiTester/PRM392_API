using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.DTOs.PeerReview;
using PRM392_API.Services.Interface;

namespace PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeerReviewController : ControllerBase
    {
        private readonly IPeerReviewService _peerReviewService;
        public PeerReviewController(IPeerReviewService peerReviewService)
        {
            _peerReviewService = peerReviewService;
        }

        [HttpGet("get-peer-review")]
        public async Task<IActionResult> GetPeerReviewsByAssignmentId([FromQuery] int reviewerId,
            [FromQuery] int revieweeId, [FromQuery] int assignmentId, [FromQuery] int groupId)
        {
            var result = await _peerReviewService.GetPeerReviewByIdAsync(reviewerId, revieweeId, assignmentId, groupId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add-peer-review")]
        public async Task<IActionResult> AddPeerReview([FromBody]AddReviewRequest request)
        {
            await _peerReviewService.AddPeerReviewAsync(request);
            return Ok();
        }

        [HttpPut("update-peer-review")]
        public async Task<IActionResult> UpdatePeerReview([FromBody] AddReviewRequest request)
        {
            await _peerReviewService.UpdatePeerReviewAsync(request);
            return Ok();
        }
    } 
}
