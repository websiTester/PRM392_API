namespace PRM392_API.DTOs.PeerReview
{
    public class AddReviewRequest
    {
        public int ReviewId { get; set; }
        public int GroupId { get; set; }
        public int AssignmentId { get; set; }
        public int ReviewerId { get; set; }
        public int RevieweeId { get; set; }
        public string? Comment { get; set; }
        public decimal? Score { get; set; }
    }
}
