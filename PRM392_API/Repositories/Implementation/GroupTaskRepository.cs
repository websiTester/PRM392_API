using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class GroupTaskRepository : IGroupTaskRepository
    {
        private readonly PRM392Context _context;
        public GroupTaskRepository(PRM392Context context)
        {
            _context = context;
        }
        public async Task CreateGroupTask(GroupTask groupTask)
        {
            await _context.GroupTasks.AddAsync(groupTask);
            await  _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteGroupTask(int id)
        {
            return await _context.GroupTasks.Where(gt => gt.TaskId == id)
                .ExecuteDeleteAsync() > 0;  
        }

        public async Task<IEnumerable<GroupTask>> GetAllGroupTasks(int assignmentId, int groupId)
        {
           return await _context.GroupTasks
                .Where(gt=>gt.AssignmentId == assignmentId && gt.GroupId == groupId)
                .Include(gt => gt.AssignedToNavigation)
                .Include(gt => gt.Group)
                .ThenInclude(g => g.StudentGroups)
                .ThenInclude(sg => sg.Student)
                .ToListAsync();
        }

        public Task<GroupTask?> GetGroupTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupTask?> UpdateGroupTask(GroupTask groupTask)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGroupTaskStatus(int taskId)
        {
            var groupTask = _context.GroupTasks.Find(taskId);
            if (groupTask != null )
            {
                if (groupTask.Status == "todo")
                {
                    groupTask.Status = "doing";
                }
                else if (groupTask.Status == "doing")
                {
                    groupTask.Status = "done";
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
