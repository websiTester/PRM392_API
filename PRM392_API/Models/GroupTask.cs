using System;
using System.Collections.Generic;

namespace PRM392_API.Models;

public partial class GroupTask
{
    public int TaskId { get; set; }

    public int? AssignmentId { get; set; }

    public int? GroupId { get; set; }

    public string? Title { get; set; }

    public string? Status { get; set; }
    public int? Points { get; set; }

    public int? AssignedTo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? AssignedToNavigation { get; set; }

    public virtual Assignment? Assignment { get; set; }

    public virtual Group? Group { get; set; }
}
