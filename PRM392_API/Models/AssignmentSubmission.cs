using System;
using System.Collections.Generic;

namespace PRM392_API.Models;

public partial class AssignmentSubmission
{
    public int SubmissionId { get; set; }

    public int? AssignmentId { get; set; }

    public int? StudentId { get; set; }

    public string? SubmitLink { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public string? TeacherComment { get; set; }

    public decimal? TeacherGrade { get; set; }

    public virtual Assignment? Assignment { get; set; }

    public virtual User? Student { get; set; }
}
