namespace PRM392_API.Models;

	public class AssignmentGrade
	{
		public int AssignmentGradeId { get; set; }
		public int? AssignmentId { get; set; }
		public int? StudentId { get; set; }
		public int? TeacherId { get; set; }
		public float? Grade { get; set; }
		public DateTime? GradedAt { get; set; }
		public string? Comment { get; set; }
		public virtual Assignment? Assignment { get; set; }
		public virtual User? Student { get; set; }
		public virtual User? Teacher { get; set; }

    
}
