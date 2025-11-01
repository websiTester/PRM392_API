namespace PRM392_API.DTOs.AssignmentSubmission
{
    public class SubmissionResponse
    {
        public int? AssignmentId { get; set; }

        public string? StudentName { get; set; }

        public string? SubmitLink { get; set; }

        public string? SubmittedAt { get; set; }
    }
}
