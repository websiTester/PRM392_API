namespace PRM392_API.ViewModels.ClassDetails
{
    public class ClassDetailTeacherViewModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public ClassMemberViewModel Teacher { get; set; }
        public List<AssignmentViewModel> Assignments { get; set; }
        public List<GroupViewModel> Groups { get; set; }
        public List<ClassMemberViewModel> AllStudents { get; set; }
    }
}
