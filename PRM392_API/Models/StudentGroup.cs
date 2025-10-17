using System;
using System.Collections.Generic;

namespace PRM392_API.Models;

public partial class StudentGroup
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int? StudentId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual User? Student { get; set; }
}
