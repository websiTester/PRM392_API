using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly PRM392Context _context;
        public UserRepository(PRM392Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUserInGroup(int groupId)
        {
            return await _context.Users
                .Where(u => u.StudentGroups.Any(sg => sg.GroupId == groupId))
                .ToListAsync();
        }
    }
}
