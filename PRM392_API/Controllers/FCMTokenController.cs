using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRM392_API.Services.Interface;

namespace PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FCMTokenController : ControllerBase
    {
        private readonly IFCMTokenService _fcmTokenService;
        public FCMTokenController(IFCMTokenService fcmTokenService)
        {
            _fcmTokenService = fcmTokenService;
        }
        [HttpPost("save-token")]
        public async Task<IActionResult> SaveToken([FromBody] DTOs.FCMToken.AddFCMTokenRequest addFCMTokenRequest)
        {
            await _fcmTokenService.SaveTokenAsync(addFCMTokenRequest);
            return Ok(new { message = "FCM token saved successfully." });
        }
    }
}
