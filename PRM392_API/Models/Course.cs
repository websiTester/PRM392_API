﻿using System;
using System.Collections.Generic;

namespace PRM392_API.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual User? CreateByNavigation { get; set; }
}
