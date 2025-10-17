using System;
using System.Collections.Generic;

namespace PRM392_API.Models;

public partial class StudentClass
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual User? Student { get; set; }
}
