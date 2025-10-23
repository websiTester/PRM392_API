using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class TeacherClassRepository : ITeacherClassRepository
    {
        PRM392Context _context;

        public TeacherClassRepository(PRM392Context context)
        {
            _context = context;
        }

        public void AddClass(Class newClass)
        {
            _context.Classes.Add(newClass);
            _context.SaveChanges();
        }

        public Class GetClassByCode(string classCode)
        {
            return _context.Classes.Where(c => c.ClassCode == classCode).Include(c => c.Course).Include(c => c.Teacher).FirstOrDefault();


        }


        public IEnumerable<Class> GetClassesByTeacherId(int teacherId)
        {
            return _context.Classes
                       .Where(c => c.TeacherId == teacherId).OrderByDescending(c => c.CreatedAt)
                       .Include(c => c.Course)
                       .Include(c=>c.Teacher)
                       .ToList();
        }

        public bool IsClassCodeExist(string classCode)
        {
            return _context.Classes.Any(c => c.ClassCode == classCode);
        }
    }
}
