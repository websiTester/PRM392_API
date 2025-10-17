using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PRM392_API.Models;

public partial class PRM392Context : DbContext
{
    public PRM392Context()
    {
    }

    public PRM392Context(DbContextOptions<PRM392Context> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
	public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupTask> GroupTasks { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PeerReview> PeerReviews { get; set; }

    public virtual DbSet<StudentClass> StudentClasses { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }
    public virtual DbSet<AssignmentGrade> AssignmentGrades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
		optionsBuilder.UseSqlServer(ConnectionString);
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Assignment>(entity =>
		{
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Class).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.ClassId);
		});

		modelBuilder.Entity<AssignmentSubmission>(entity =>
		{
			entity.HasKey(e => e.SubmissionId);

			entity.HasOne(d => d.Assignment).WithMany(p => p.AssignmentSubmissions)
				.HasForeignKey(d => d.AssignmentId);

			entity.HasOne(d => d.Student).WithMany(p => p.AssignmentSubmissions)
				.HasForeignKey(d => d.StudentId);
		});
		modelBuilder.Entity<Class>(entity =>
		{
			entity.HasKey(e => e.ClassId);

			entity.HasOne(d => d.Course).WithMany(p => p.Classes)
				.HasForeignKey(d => d.CourseId);

			entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
				.HasForeignKey(d => d.TeacherId);
		});

		modelBuilder.Entity<Course>(entity =>
		{
			entity.HasKey(e => e.Id);

			entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Courses)
				.HasForeignKey(d => d.CreateBy);
		});

		modelBuilder.Entity<Group>(entity =>
		{
			entity.HasKey(e => e.GroupId);

			entity.HasOne(d => d.Class).WithMany(p => p.Groups)
				.HasForeignKey(d => d.ClassId);
		});

		modelBuilder.Entity<GroupTask>(entity =>
		{
			entity.HasKey(e => e.TaskId);

			entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.GroupTasks)
				.HasForeignKey(d => d.AssignedTo);

			entity.HasOne(d => d.Assignment).WithMany(p => p.GroupTasks)
				.HasForeignKey(d => d.AssignmentId);

			entity.HasOne(d => d.Group).WithMany(p => p.GroupTasks)
				.HasForeignKey(d => d.GroupId);
		});

		modelBuilder.Entity<Material>(entity =>
		{
			entity.HasKey(e => e.MaterialId);

			entity.HasOne(d => d.Assignment).WithMany(p => p.Materials)
				.HasForeignKey(d => d.AssignmentId);
		});

		modelBuilder.Entity<Notification>(entity =>
		{
			entity.HasKey(e => e.NotificationId);

			entity.HasOne(d => d.Class).WithMany(p => p.Notifications)
				.HasForeignKey(d => d.ClassId);
		});

		modelBuilder.Entity<AssignmentGrade>(entity =>
		{
			entity.HasKey(e => e.AssignmentGradeId);
			entity.HasOne(e => e.Assignment).WithMany(e => e.AssignmentGrades).HasForeignKey(e => e.AssignmentId);
			entity.HasOne(e => e.Student).WithMany(e => e.StudentGrades).HasForeignKey(e => e.StudentId);
			entity.HasOne(e => e.Teacher).WithMany(e => e.TeacherGrades).HasForeignKey(e => e.TeacherId);

		});

		modelBuilder.Entity<PeerReview>(entity =>
		{
			entity.HasKey(e => e.ReviewId);

			entity.HasOne(d => d.Assignment).WithMany(p => p.PeerReviews)
				.HasForeignKey(d => d.AssignmentId);

			entity.HasOne(d => d.Group).WithMany(p => p.PeerReviews)
				.HasForeignKey(d => d.GroupId);

			entity.HasOne(d => d.Reviewee).WithMany(p => p.PeerReviewReviewees)
				.HasForeignKey(d => d.RevieweeId);

			entity.HasOne(d => d.Reviewer).WithMany(p => p.PeerReviewReviewers)
				.HasForeignKey(d => d.ReviewerId);
		});

		modelBuilder.Entity<StudentClass>(entity =>
		{
			entity.HasKey(e => e.Id);

			entity.HasOne(d => d.Class).WithMany(p => p.StudentClasses)
				.HasForeignKey(d => d.ClassId);

			entity.HasOne(d => d.Student).WithMany(p => p.StudentClasses)
				.HasForeignKey(d => d.StudentId);
		});

		modelBuilder.Entity<StudentGroup>(entity =>
		{
			entity.HasKey(e => e.Id);

			entity.HasOne(d => d.Group).WithMany(p => p.StudentGroups)
				.HasForeignKey(d => d.GroupId);

			entity.HasOne(d => d.Student).WithMany(p => p.StudentGroups)
				.HasForeignKey(d => d.StudentId);
		});

		OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
