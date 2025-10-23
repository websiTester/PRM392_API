namespace PRM392_API.DTOs.GroupTask
{
    public class AddGroupTaskRequest
    {
        public int? AssignmentId { get; set; }
        public int? GroupId { get; set; }
        public string? Title { get; set; }
        public int? Points { get; set; }
        public int? AssignedTo { get; set; }
    }
}
