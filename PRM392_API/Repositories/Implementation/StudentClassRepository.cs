using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class StudentClassRepository : IStudentClassRepository
    {
        private PRM392Context _context;
        public StudentClassRepository(PRM392Context context)
        {
            _context = context;
        }

        public IEnumerable<StudentClass> GetClassesByStudentId(int studentId)
        {
            return _context.StudentClasses
                           .Where(sc => sc.StudentId == studentId).OrderByDescending(sc => sc.Id)
                           .Include(sc => sc.Class)
                               .ThenInclude(c => c.Course)
                           .Include(sc => sc.Class)
                               .ThenInclude(c => c.Teacher)

                           .ToList();
        }

        public bool IsStudentInClass(int studentId, int classId)
        {
            return _context.StudentClasses
                           .Any(sc => sc.StudentId == studentId && sc.ClassId == classId);
        }

        public void AddStudentToClass(StudentClass studentClass)
        {
            _context.StudentClasses.Add(studentClass);
            _context.SaveChanges();
        }
    }
}
