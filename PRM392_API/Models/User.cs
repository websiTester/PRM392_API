﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PRM392_API.Models;

public partial class User 
{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
	public string? Password { get; set; }
    public string? Avatar { get; set; }
    public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public int? AccountStatus { get; set; }
    public bool isActive { get; set; }
    public DateTime? CreateAt { get; set; }
    public int? RoleId { get; set; }
	public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

	public virtual ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<GroupTask> GroupTasks { get; set; } = new List<GroupTask>();

    public virtual ICollection<PeerReview> PeerReviewReviewees { get; set; } = new List<PeerReview>();

    public virtual ICollection<PeerReview> PeerReviewReviewers { get; set; } = new List<PeerReview>();

    public virtual ICollection<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();

    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();
	public virtual ICollection<AssignmentGrade> StudentGrades { get; set; } = new List<AssignmentGrade>();

	public virtual ICollection<AssignmentGrade> TeacherGrades { get; set; } = new List<AssignmentGrade>();
}
