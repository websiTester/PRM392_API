using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class ClassDetailRepository : IClassDetailRepository
    {
        private readonly PRM392Context _context;
        public ClassDetailRepository(PRM392Context context)
        {
            _context = context;
        }
        public async Task<Class> GetClassByIdAsync(int classId)
        {
            return await _context.Classes
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(c => c.ClassId == classId);
        }

        public async Task<IEnumerable<User>> GetStudentsByClassIdAsync(int classId)
        {
            return await _context.StudentClasses
                .Where(sc => sc.ClassId == classId)
                .Select(sc => sc.Student)
                .ToListAsync();
        }

        public async Task<User> GetTeacherByClassIdAsync(int classId)
        {
            var aClass = await _context.Classes
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(c => c.ClassId == classId);
            return aClass?.Teacher;
        }

        public async Task<bool> IsUserStudentOfClassAsync(int classId, int userId)
        {
            return await _context.Classes
                .AnyAsync(c => c.ClassId == classId && c.TeacherId == userId);
        }

        public async Task<bool> IsUserTeacherOfClassAsync(int classId, int userId)
        {
            return await _context.StudentClasses
                .AnyAsync(sc => sc.ClassId == classId && sc.StudentId == userId);
        }
    }
}
