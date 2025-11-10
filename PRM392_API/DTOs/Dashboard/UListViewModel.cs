namespace PRM392_API.DTOs.Dashboard
{
    public class UListViewModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = "";
        public string? Email { get; set; }
        public string RoleName { get; set; } = "";
        public bool IsActive { get; set; }
        public string? Avatar { get; set; }
    }
}
