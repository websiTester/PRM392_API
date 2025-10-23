using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        PRM392Context _context;
        public CourseRepository(PRM392Context context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetCoursesByTeacherId(int teacherId)
        {
            return _context.Courses.Where(c => c.CreateBy == teacherId).ToList();
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public bool IsCourseNameExist(string name, int teacherId)
        {
            return _context.Courses.Any(c => c.Name == name && c.CreateBy == teacherId);
        }
    }
}
