using PRM392_API.Models;

namespace PRM392_API.Repositories.Interface
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCoursesByTeacherId(int teacherId);
        void AddCourse(Course course);
        bool IsCourseNameExist(string name,int teacherId);
    }
}
