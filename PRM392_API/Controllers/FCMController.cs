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

        [HttpPost]
        public async Task<IActionResult> SendMessage(int classId)
        {
            int[] students = await _classService.GetUserIdsByClassIdAsync(classId);
            if (students == null || !students.Any())
            {
                return Ok(new { Message = "No students in this class." });
            }

            var fcmTokens = await _fCMTokenService.GetTokensByUserIdAsync(students);

            var tokenStrings = fcmTokens.Select(t => t.Token).ToList();

            if (!tokenStrings.Any())
            {
                return Ok(new { Message = "No valid FCM tokens found for these students." });
            }
            var message = new MulticastMessage()
            {
                Notification = new Notification
                {
                    Title = "Bạn có bài tập mới!",
                    Body = "Admin vừa thêm bài tập"
                },
                Tokens = tokenStrings
            };

            try
            {
                BatchResponse response = await _firebaseMessaging.SendEachForMulticastAsync(message);

                Console.WriteLine($"Successfully sent to: {response.SuccessCount} tokens");
                Console.WriteLine($"Failed to send to: {response.FailureCount} tokens");
                if (response.FailureCount > 0)
                {
                    var failedTokens = new List<string>();
                    for (int i = 0; i < response.Responses.Count; i++)
                    {
                        if (!response.Responses[i].IsSuccess)
                        {
                            failedTokens.Add(tokenStrings[i]);
                        }
                    }
                    Console.WriteLine("Failed tokens: " + string.Join(", ", failedTokens));
                }

                return Ok(new
                {
                    Message = "Notifications sent.",
                    SuccessCount = response.SuccessCount,
                    FailureCount = response.FailureCount
                });
            }
            catch (FirebaseMessagingException ex)
            {
                Console.WriteLine("Error sending multicast message: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to send notifications.");
            }
        }
    }
}
