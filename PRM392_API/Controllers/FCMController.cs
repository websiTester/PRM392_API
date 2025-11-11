using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.Services.Implementation;
using PRM392_API.Services.Interface;

namespace PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FCMController : ControllerBase
    {
        private readonly FirebaseMessaging _firebaseMessaging;
        private readonly IClassService _classService;
        private readonly IFCMTokenService _fCMTokenService;
        //private readonly 

        public FCMController(FirebaseMessaging firebaseMessaging, IClassService classService, IFCMTokenService fCMTokenService)
        {
            _firebaseMessaging = firebaseMessaging;
            _classService = classService;
            _fCMTokenService = fCMTokenService;
        }
        [HttpGet("get-classes")]
        public async Task<IActionResult> GetClasses(int userId)
        {
            var classes = await _fCMTokenService.GetClassByUserId(userId);
            return Ok(classes);
        }
        [HttpGet("get-groupId")]
        public async Task<IActionResult> GetGroupId([FromQuery]int classId, [FromQuery] int userId)
        {
            var groupId = await _fCMTokenService.GetGroupIdByStudentIdAndClassId(classId, userId);
            return Ok(groupId);
        }
    }
}
