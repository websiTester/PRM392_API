namespace PRM392_API.ViewModels.ClassDetails
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsGroupAssignment { get; set; }
        public string StudentGradeDisplay { get; set; }
        public List<GroupGradeViewModel> GroupGrades { get; set; }
    }
}
