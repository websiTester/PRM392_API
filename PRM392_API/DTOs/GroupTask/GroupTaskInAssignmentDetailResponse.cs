namespace PRM392_API.DTOs.GroupTask
{
    public class SimpleUser
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
    public class GroupTaskInAssignmentDetailResponse
    {
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string? Status { get; set; }
        public int Points { get; set; }
        public string? AssignedToName { get; set; }
        public ICollection<SimpleUser>? Members { get; set; }
    }
}
