using System.ComponentModel.DataAnnotations;

namespace PRM392_API.ViewModels
{
    public class CreateClassViewModel
    {
        public string ClassName { get; set; }
        public int TeacherId { get; set; }
        public bool IsNewCourse { get; set; }
        public int? ExistingCourseId { get; set; }
        
        public string NewCourseName { get; set; }
        public string NewCourseDescription { get; set; }
    }
}
