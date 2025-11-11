using System.ComponentModel.DataAnnotations;

namespace PRM392_API.ViewModels
{
    public class ClassListViewModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public string CourseName { get; set; }
        public string TeacherFullName { get; set; }
    }
    public class JoinClassViewModel
    {
       public int studentId { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Mã lớp không được dài quá 10 ký tự.")]
        public string ClassCode { get; set; }
    }
}
