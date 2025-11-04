namespace PRM392_API.DTOs.AssignmentSubmission
{
    public class SubmitRequest
    {
        public int? AssignmentId { get; set; }

        public int? StudentId { get; set; }

        public string? SubmitLink { get; set; }
    }
}
