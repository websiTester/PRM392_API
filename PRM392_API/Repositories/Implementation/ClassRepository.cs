using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class ClassRepository : IClassRepository
    {
        private readonly PRM392Context _context;
        public ClassRepository(PRM392Context context)
        {
            _context = context;
        }
        public async Task<int[]> GetUserIdsByClassIdAsync(int classId)
        {
            return await _context.StudentClasses
                .Where(sc => sc.ClassId == classId && sc.StudentId != null)
                .Select(sc => sc.StudentId!.Value)
                .ToArrayAsync();
        }
    }
}
