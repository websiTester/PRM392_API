namespace PRM392_API.ViewModels
{
    public class StudentClassListDto
    {
        public int StudentClassId { get; set; } // ID của StudentClass (để định danh mối quan hệ)
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public string CourseName { get; set; }
        public string TeacherFullName { get; set; }
    }
}
