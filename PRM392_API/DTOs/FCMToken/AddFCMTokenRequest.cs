namespace PRM392_API.DTOs.FCMToken
{
    public class AddFCMTokenRequest
    {
        public int UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public string? DeviceName { get; set; }
    }
}
