using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class GroupRepository : IGroupRepository
    {
        private readonly PRM392Context _context;
        public GroupRepository(PRM392Context context)
        {
            _context = context;
        }

        public async Task AddStudentToGroupAsync(int groupId, int studentId)
        {
            var exists = await _context.StudentGroups
                .AnyAsync(sg => sg.GroupId == groupId && sg.StudentId == studentId);

            if (!exists)
            {
                var studentGroup = new StudentGroup
                {
                    GroupId = groupId,
                    StudentId = studentId
                };
                await _context.StudentGroups.AddAsync(studentGroup);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Group> CreateGroupAsync(Group group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            var group = await _context.Groups.FindAsync(groupId);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Group> GetGroupByIdAsync(int groupId)
        {
            return await _context.Groups.FindAsync(groupId);
        }

        public async Task<int?> GetGroupIdByStudentIdAsync(int studentId, int classId)
        {
            return await _context.StudentGroups
                .Where(sg => sg.StudentId == studentId && sg.Group.ClassId == classId)
                .Select(sg => sg.GroupId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Group>> GetGroupsByClassIdAsync(int classId)
        {
            return await _context.Groups
                .Where(g => g.ClassId == classId)
                .Include(g => g.Leader)
                .ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetGroupsByClassIdWithMembersAsync(int classId)
        {
            return await _context.Groups
                .Where(g => g.ClassId == classId)
                .Include(g => g.Leader)
                .Include(g => g.StudentGroups)
                    .ThenInclude(sg => sg.Student)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetMembersByGroupIdAsync(int groupId)
        {
            return await _context.StudentGroups
                .Where(sg => sg.GroupId == groupId)
                .Select(sg => sg.Student)
                .ToListAsync();
        }

        public async Task<Group> GetStudentGroupInClassAsync(int classId, int studentId)
        {
            var studentGroup = await _context.StudentGroups
                .Include(sg => sg.Group) 
                .FirstOrDefaultAsync(sg => sg.StudentId == studentId && sg.Group.ClassId == classId);

            return studentGroup?.Group;
        }

        public async Task RemoveStudentFromGroupAsync(int groupId, int studentId)
        {
            var studentGroup = await _context.StudentGroups
                .FirstOrDefaultAsync(sg => sg.GroupId == groupId && sg.StudentId == studentId);

            if (studentGroup != null)
            {
                _context.StudentGroups.Remove(studentGroup);
                await _context.SaveChangesAsync();
            }
        }
    }
}
