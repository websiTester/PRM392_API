namespace PRM392_API.DTOs.Dashboard
{
    public class DashboardViewModel
    {
        public int TotalTeachers { get; set; }

        public int TotalClasses { get; set; }
        public int TotalCourses { get; set; }

        // Trong DB chưa có bảng "Visits", tạm thời hard-code hoặc tính từ log khác
        public int TotalStudents { get; set; }
    }
}
