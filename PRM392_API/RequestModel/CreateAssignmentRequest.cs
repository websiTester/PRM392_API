namespace PRM392_API.RequestModel
{
    public class CreateAssignmentRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsGroupAssignment { get; set; }
    }
}
